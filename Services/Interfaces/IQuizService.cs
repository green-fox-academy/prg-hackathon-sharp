using programmersGuide.Models;
using System.Collections.Generic;

namespace programmersGuide.Services.Interfaces
{
    public interface IQuizService
    {
        public string ProcessAnswers(string answer);
        public List<Quiz> ReturnCounters();
    }
}
