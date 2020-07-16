using programmersGuide.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IQuizService
    {
        public string ProcessAnswers(string answer);
        public Quiz ReturnCounters();
    }
}
