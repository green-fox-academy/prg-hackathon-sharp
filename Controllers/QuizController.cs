using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using programmersGuide.Services;
using programmersGuide.Services.Interfaces;

namespace programmersGuide.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpPost("quiz")]
        public IActionResult QuizAnswers([FromBody]string answer)
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
