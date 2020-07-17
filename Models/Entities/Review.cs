using programmersGuide.Models.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace programmersGuide.Models
{
    public class Review
    {
        public long ID { get; set; }
        public DateTime Time {get; set;}
        public string Name { get; set; }  
        public Role Role { get; set; }
        public Int16 Rating { get; set; }
        public string ReviewBody { get; set; }

        public Review()
        {
        }

        public Review(ReviewDTO reviewDTO)
        {
            Time = reviewDTO.Date ?? default;
            Name = reviewDTO.Name ?? default;
            Role = reviewDTO.Role ?? default;
            Rating = reviewDTO.Rating ?? default;
            ReviewBody = reviewDTO.ReviewBody ?? default;
        }
    }
}
