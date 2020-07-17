namespace programmersGuide.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }

        public ProgrammingPath ProgrammingPath { get; set; }
        public int ResultCount { get; set; }
    }
}
