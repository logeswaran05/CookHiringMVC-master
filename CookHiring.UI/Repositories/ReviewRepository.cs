using CookHiring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookHiring.UI.Repositories
{
    public class ReviewRepository
    {
        public ApplicationDbContext dbEntities;
        public ReviewRepository()
        {
            dbEntities = new ApplicationDbContext();
        }
        public List<Review> GetReview(int id)
        {
            var reviews = dbEntities.Review.Where(item => item.jobSeekerId == id).ToList();
            return reviews;
        }
        public Review AddReview( Review data)
        {
            Review review = dbEntities.Review.Add(data);
            return review;
        }

        }
    }