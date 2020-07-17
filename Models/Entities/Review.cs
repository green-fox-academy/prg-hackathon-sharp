using programmersGuide.Models.Entities;
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
        public string ReviewBody { get; set; }

        public Review()
        {
        }

        public Review(Review review)
        {
            Time = review.Time;
            Name = review.Name ?? default;
            ProgrammingPath = review.ProgrammingPath;
            Rating = review.Rating;
            ReviewBody = review.ReviewBody ?? default;
        }
    }
}
