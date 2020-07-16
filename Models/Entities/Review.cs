﻿using programmersGuide.Models.DTOs;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace programmersGuide.Models
{
    public class Review
    {
        [Key]
        public long ID { get; set; }
        public DateTime Time {get; set;}
        public string Name { get; set; }  
        public Role Role { get; set; }
        public Int16 QuizRating { get; set; }
        public Int16 ContentRating { get; set; }
        public Int16 UXRating { get; set; }
        public string ReviewBody { get; set; }

        public Review(ReviewDTO reviewDTO)
        {
            Time = reviewDTO.Time ?? default;
            Name = reviewDTO.Name ?? default;
            Role = reviewDTO.Role ?? default;
            QuizRating = reviewDTO.QuizRating ?? default;
            ContentRating = reviewDTO.ContentRating ?? default;
            UXRating = reviewDTO.UXRating ?? default;
            ReviewBody = reviewDTO.ReviewBody ?? default;
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
