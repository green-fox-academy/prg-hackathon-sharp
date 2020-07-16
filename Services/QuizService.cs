using programmersGuide.Context;
using programmersGuide.Models.Entities;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace programmersGuide.Services
{
    public class QuizService
    {
        private readonly ApplicationDbContext dbContext;

        public QuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string ProcessAnswers(string answer) //abbcb
        {
            var firstTwoPairs = answer.GroupBy(c => c).OrderByDescending(c => c.Count()).Take(2);
            var result = "backend";
            if (firstTwoPairs.FirstOrDefault().Key == 'c' || firstTwoPairs.ElementAt(0).Count() == firstTwoPairs.ElementAt(1).Count())
            {
                result = "fullstack";
            }
            else if (firstTwoPairs.FirstOrDefault().Key == 'a')
            {
                result = "frontend";
            }
            return result;
        }


        public Quiz ReturnCounters()
        {
            var counter = dbContext.Quiz;
            return counter;
        }
    }
}