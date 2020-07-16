using programmersGuide.Models.DTOs;

namespace programmersGuide.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public Role ResultType { get; set; }
        public long ResultCount { get; set; }
    }
}
