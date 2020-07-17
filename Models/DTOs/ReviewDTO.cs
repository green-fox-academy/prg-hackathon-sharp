using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace programmersGuide.Models.DTOs
{
    public class ReviewDTO
    {
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public Role? Role { get; set; }
        public Int16? Rating { get; set; }
        public string? ReviewBody { get; set; }

        public ReviewDTO(Review review)
        {
            Date = review.Time.Date;
            Name = review.Name;
            Role = review.Role;
            Rating = review.Rating;
            ReviewBody = review.ReviewBody;
        }
    }

}
