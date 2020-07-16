using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Services;

namespace programmersGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuizService quizService;

        public HomeController(QuizService quizService)
        {
            this.quizService = quizService;
        }
        [HttpPost("quiz")]
        public IActionResult QuizAnswers(string answer) // abbabb;
        {
            quizService.ProcessAnswers(answer);
            return View();
        }
    }
}
