using programmersGuide.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IReviewService
    {
        public Task SaveReview(ReviewDTO reviewDTO);
        public Task<List<ReviewDTO>> LoadAllReviews();
        public Task<List<ReviewDTO>> RandomReviews(int reviewCount = 3);
    }
}