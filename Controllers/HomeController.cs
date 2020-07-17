using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Models.DTOs;
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

        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost("Review")]
        public async Task<IActionResult> SaveReview(ReviewDTO reviewDTO)
        {
            await reviewService.SaveReview(reviewDTO);
            return Redirect("Index");
        }
    }
}
