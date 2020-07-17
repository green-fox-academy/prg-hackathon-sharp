using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Models;
using programmersGuide.Services;
using programmersGuide.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace programmersGuide.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;
        private readonly UserManager<User> userManager;

        public QuizController(IQuizService quizService, UserManager<User> userManager)
        {
            this.quizService = quizService;
            this.userManager = userManager;
        }

        [HttpPost("quiz/quiz")]
        public async Task<IActionResult> QuizAnswers(QuizAnswers quizAnswers)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.FindByIdAsync(currentUserName);
            var answer = string.Concat(quizAnswers.Ans1, quizAnswers.Ans2, quizAnswers.Ans3, quizAnswers.Ans4, quizAnswers.Ans5);
            var result = quizService.ProcessAnswers(answer, user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("counter")]
        public IActionResult AnswerCounter()
        {
            var counter = quizService.ReturnCounters();
            return Ok(counter);
        }
    }
}
