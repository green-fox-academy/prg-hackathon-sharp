using System;

namespace programmersGuide.Models
{
    public class Review
    {
        public long ID { get; set; }
        public DateTime Time {get; set;}
        public string Name { get; set; }  
        public ProgrammingPath ProgrammingPath { get; set; }
        public Int16 Rating { get; set; }
        public string RevText { get; set; }
    }
}
