using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using programmersGuide.Context;
using programmersGuide.Helpers;
using programmersGuide.Models.DTOs;
using programmersGuide.Models.Entities;
using programmersGuide.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace programmersGuide.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly User user;

        public UserService(ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            this.dbContext = dbContext;
            var username = contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Username");
            if (username != null)
            {
                user = dbContext.Users.FirstOrDefault(u => u.Username == username.Value);
            }
        }

        public async Task RegUser(UserDTO userDto)
        {
            byte[] salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            string hashed = GetHashedPassword(userDto.Password, salt);
            var user = new User()
            {
                Avatar = "https://forums.opera.com/assets/uploads/profile/192104-profileavatar.png",
                Username = userDto.Username,
                Email = userDto.Email,
                Password = hashed,
                Salt = Convert.ToBase64String(salt)
            };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> AuthenticateUser(UserDTO userDto)
        {
            string hashed = GetHashedPassword(userDto.Password);
            return hashed == user.Password ? user : null;
        }

        public async Task<string> GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("Username", user.Username)
            };

            var token = new JwtSecurityToken(AppSettings.JwtIssuer,
              AppSettings.JwtIssuer,
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ChangeAvatar(string avatar)
        {
            user.Avatar = avatar;
            dbContext.Update(user);
            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ChangeEmail(string email)
        {
            user.Email = email;
            dbContext.Update(user);
            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ChangePassword(UserDTO userDto)
        {
            string hashed = GetHashedPassword(userDto.Password);
            if (hashed == user.Password)
            {
                var newhashed = GetHashedPassword(userDto.NewPassword);
                user.Password = newhashed;
                dbContext.Update(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetHashedPassword(string password, byte[] salt = null)
        {
            salt = Convert.FromBase64String(user.Salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
