using programmersGuide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace programmersGuide.Services.Interfaces
{
    public interface IReviewService
    {
        public Task SaveReview(Review review, User user);
        public Task<List<Review>> LoadAllReviews();
        public Task<List<Review>> RandomReviews(int reviewCount = 3);
    }
}