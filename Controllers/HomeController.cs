using programmersGuide.Models;
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace programmersGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IMPService mPService;
        private readonly UserManager<User> userManager;

        public HomeController(IReviewService reviewService, IMPService mpService, UserManager<User> userManager)
        {
            this.reviewService = reviewService;
            this.mPService = mpService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var vm = new HomeViewModel();
            if(currentUser.Identity.Name != null)
            {
                var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                vm.User = await userManager.FindByIdAsync(currentUserName);
            }
            return View(vm);
        }

        public IActionResult RegisterForm()
        {
            return View();
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost("Review")]
        public async Task<IActionResult> SaveReview(Review review)
        {
            await reviewService.SaveReview(review);
            return Redirect("Index");
        }
    }
}
