using programmersGuide.Models.DTOs;

namespace programmersGuide.Models.Entities
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string Answers { get; set; }
        public Role Result { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
