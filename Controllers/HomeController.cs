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

    }
}
