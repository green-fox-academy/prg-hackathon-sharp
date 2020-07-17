using Microsoft.EntityFrameworkCore;
using programmersGuide.Context;
using programmersGuide.Models;
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

        public async Task SaveReview(Review review)
        {
            await dbContext.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Review>> LoadAllReviews()
        {
            return dbContext.Reviews.Any() ? await dbContext.Reviews.ToListAsync() : new List<Review>();
        }

        public async Task<List<Review>> RandomReviews(int reviewCount = 3)
        {
            var Ids = dbContext.Reviews.Any() ? dbContext.Reviews.Select(r => r.ID).ToList() : new List<long>();
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
                return await dbContext.Reviews.Where(r => randomIds.Contains(r.ID)).ToListAsync();
            }
            else
            {
                return await dbContext.Reviews.ToListAsync();
            }
        }
    }
}
