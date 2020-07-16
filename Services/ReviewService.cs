using Microsoft.EntityFrameworkCore;
using programmersGuide.Context;
using programmersGuide.Models;
using programmersGuide.Models.DTOs;
using programmersGuide.Services.Interfaces;
using System;
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
            await dbContext.AddAsync(new Review(reviewDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ReviewDTO>> LoadAllReviews()
        {
            return dbContext.Reviews.Any() ? await dbContext.Reviews.Select(r => new ReviewDTO(r)).ToListAsync() : new List<ReviewDTO>();
        }

        public async Task<List<ReviewDTO>> RandomReviews(int reviewCount = 3)
        {
            var Ids = dbContext.Reviews.Select(r => r.ID).ToList();
            var randomIds = new List<long>();
            if (Ids.Count > reviewCount)
            {
                while (randomIds.Count() <= reviewCount)
                {
                    var randId = Ids[new Random().Next(Ids.Count())];
                    if (!randomIds.Contains(randId))
                    {
                        randomIds.Add(randId);
                    }
                }
                return await dbContext.Reviews.Where(r => randomIds.Contains(r.ID)).Select(r => new ReviewDTO(r)).ToListAsync();
            }
            else
            {
                return await dbContext.Reviews.Select(r => new ReviewDTO(r)).ToListAsync();
            }
        }
    }
}
