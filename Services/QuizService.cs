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
        public string ProcessAnswers(string answer) 
        {
            var firstTwoPairs = answer.GroupBy(c => c).OrderByDescending(c => c.Count()).Take(2);
            var result = string.Empty;
            var quiz = dbContext.Quiz.FirstOrDefault();
            if (firstTwoPairs.FirstOrDefault().Key == 'c' || firstTwoPairs.ElementAt(0).Count() == firstTwoPairs.ElementAt(1).Count())
            {
                result = "fullstack";
                quiz.FullStack++;
            }
            else if (firstTwoPairs.FirstOrDefault().Key == 'a')
            {
                result = "frontend";
                quiz.FrontEnd++;
            }
            else
            {
                result = "backend";
                quiz.BackEnd++;
            }
            dbContext.SaveChanges();
            return result;
        }

        public Quiz ReturnCounters()
        {
            var counter = dbContext.Quiz.FirstOrDefault();
            return counter;
        }
    }
}