
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace CookHiring.Data
{
    public class ApplicationDbContext : DbContext
    {

        static string con = @"Data Source =DESKTOP-MUE0CC2\SQLEXPRESS;Initial Catalog = CookHiringMVC; Integrated Security = True";
        public ApplicationDbContext() : base(con)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get;  set; }
        public DbSet<JobSeekerProfile> JobSeekersProfile {get; set;}
        public DbSet<Appliedjobs> AppliedJobs {get; set;}
        public DbSet<Review> Review {get; set;}
    }
}
