using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Models;
using programmersGuide.Services;
using programmersGuide.Services.Interfaces;
using System.Collections.Generic;

namespace programmersGuide.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpPost("quiz/quiz")]
        public IActionResult QuizAnswers(QuizAnswers quizAnswers)
        {
            var answer = string.Concat(quizAnswers.Ans1, quizAnswers.Ans2, quizAnswers.Ans3, quizAnswers.Ans4, quizAnswers.Ans5);
            var result = quizService.ProcessAnswers(answer);
            return Ok(result);
        }

        [HttpGet("counter")]
        public IActionResult AnswerCounter()
        {
            var counter = quizService.ReturnCounters();
            return Ok(counter);
        }
    }
}
