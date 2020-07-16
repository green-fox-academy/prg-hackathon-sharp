using programmersGuide.Models.DTOs;
using programmersGuide.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IUserService
    {
        Task RegUser(UserDTO userDto);
        Task<User> AuthenticateUser(UserDTO userDto);
        Task<string> GenerateJSONWebToken(User user);
        Task<bool> ChangeAvatar(string avatar);
        Task<bool> ChangeEmail(string email);
        Task<bool> ChangePassword(UserDTO userDto);
    }
}
