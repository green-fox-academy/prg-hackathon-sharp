using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Services.Interfaces;

namespace programmersGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService reviewService;

        public HomeController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
