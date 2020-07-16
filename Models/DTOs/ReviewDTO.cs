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
        public Int16? QuizRating { get; set; }
        public Int16? ContentRating { get; set; }
        public Int16? UXRating { get; set; }
        public string? ReviewBody { get; set; }

        public ReviewDTO(Review review)
        {
            Date = review.Time.Date;
            Name = review.Name;
            Role = review.Role;
            QuizRating = review.QuizRating;
            ContentRating = review.ContentRating;
            UXRating = review.UXRating;
            ReviewBody = review.ReviewBody;
        }
    }
    public enum Role
    {
        [EnumMember(Value = "frontend")]
        frontend,
        [EnumMember(Value = "backend")]
        backend,
        [EnumMember(Value = "fullstack")]
        fullstack
    }
}
