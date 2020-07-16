﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using programmersGuide.Context;
using programmersGuide.Models.DTOs;
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
            var number = 0;
            if (!dbContext.Quiz.Any())
            {
                InitialQuizSeed();
            }
            if (firstTwoPairs.FirstOrDefault().Key == 'c' || firstTwoPairs.ElementAt(0).Count() == firstTwoPairs.ElementAt(1).Count())
            {
                result = "fullstack";
                number = 2;
            }
            else if (firstTwoPairs.FirstOrDefault().Key == 'a')
            {
                result = "frontend";
            }
            else
            {
                result = "backend";
                number = 1;
            }
            dbContext.Quiz.FirstOrDefault(q => q.ResultType == (Role)number).ResultCount++;
            dbContext.SaveChanges();
            return result;
        }

        public List<Quiz> ReturnCounters()
        {
            return dbContext.Quiz.ToList();
        }

        public void InitialQuizSeed()
        {
            var frontendResult = new Quiz { ResultType = (Role)0, ResultCount = 0 };
            var backendResult = new Quiz { ResultType = (Role)1, ResultCount = 0 };
            var fullstackResult = new Quiz { ResultType = (Role)2, ResultCount = 0 };
            dbContext.Quiz.Add(frontendResult);
            dbContext.Quiz.Add(backendResult);
            dbContext.Quiz.Add(fullstackResult);
            dbContext.SaveChanges();
        }
    }
}