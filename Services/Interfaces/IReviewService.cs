using programmersGuide.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IReviewService
    {
        Task SaveReview(ReviewDTO reviewDTO);
        Task<List<ReviewDTO>> LoadAllReviews();
    }
}