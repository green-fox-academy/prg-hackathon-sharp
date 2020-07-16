﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult QuizAnswers(string answer)
        {
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
