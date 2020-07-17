using programmersGuide.Context;
using programmersGuide.Models.Entities;
using programmersGuide.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace programmersGuide.Services
{
    public class QuizService : IQuizService
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
            }
            else if (firstTwoPairs.FirstOrDefault().Key == 'a')
            {
                result = "frontend";
            }
            else
            {
                result = "backend";
            }
            dbContext.SaveChanges();
            return result;
        }

        public List<Quiz> ReturnCounters()
        {
            return dbContext.Quiz.ToList();
        }
    }
}