using Microsoft.EntityFrameworkCore;
using programmersGuide.Context;
using programmersGuide.Models;
using programmersGuide.Models.DTOs;
using programmersGuide.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveReview(ReviewDTO reviewDTO)
        {
            var result = new Review(reviewDTO);
            await dbContext.AddAsync(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ReviewDTO>> LoadAllReviews()
        {
            return await dbContext.Reviews.Select(r => new ReviewDTO(r)).ToListAsync();
        }
    }
}
