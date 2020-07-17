using programmersGuide.Models;
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Services.Interfaces;

namespace programmersGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IMPService mPService;

        public HomeController(IReviewService reviewService, IMPService mpService)
        {
            this.reviewService = reviewService;
            this.mPService = mpService;
        }

        public IActionResult Index()
        {
            return View();
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
