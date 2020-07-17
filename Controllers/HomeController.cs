using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var vm = new HomeViewModel();
            if (currentUser.Identity.Name != null)
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

        public IActionResult ReviewForm()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        [Authorize]
        [HttpPost("Review")]
        public async Task<IActionResult> SaveReview(Review review)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.FindByIdAsync(currentUserName);
            await reviewService.SaveReview(review, user);
            return Redirect("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            ClaimsPrincipal currentUser = this.User;
            var vm = new HomeViewModel();
            if (currentUser.Identity.Name != null)
            {
                var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                vm.User = await userManager.FindByIdAsync(currentUserName);
            }
            return View(vm);
        }
    }
}