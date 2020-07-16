using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Models.DTOs
{
    public class ReviewDTO
    {
        [Key]
        public long? ID { get; set; }
        public DateTime? Time { get; set; }
        public string? Name { get; set; }
        public Role? Role { get; set; }
        public Int16? Rating { get; set; }
        public string? ReviewBody { get; set; }

        public ReviewDTO(Review review)
        {
            ID = review.ID;
            Time = review.Time;
            Name = review.Name;
            Role = review.Role;
            Rating = review.Rating;
            ReviewBody = review.ReviewBody;
        }
    }
}
