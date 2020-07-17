using programmersGuide.Models;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetCurrentUser(string username);
    }
}
