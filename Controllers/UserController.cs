using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Models;
using programmersGuide.Services.Interfaces;
using System.Threading.Tasks;

namespace programmersGuide.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UserController(UserManager<User> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid && model.Password.Equals(model.ConfirmPassword))
            {
                User user = new User
                {
                    UserName = model.UserName,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("RegisterForm","Home",model);
        }
    }
}
