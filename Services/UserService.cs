using Microsoft.EntityFrameworkCore;
using programmersGuide.Context;
using programmersGuide.Models;
using programmersGuide.Services.Interfaces;
using System.Threading.Tasks;

namespace programmersGuide.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetCurrentUser(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
