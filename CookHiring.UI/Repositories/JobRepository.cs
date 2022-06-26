using CookHiring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookHiring.UI.Repositories
{
    public class JobRepository
    {
        public ApplicationDbContext dbEntities;
        public JobRepository()
        {
            dbEntities = new ApplicationDbContext();
        }
        public List<Job> GetJobs()
        {
            return dbEntities.Jobs.ToList();
        }
        public void AddJob(Job job)
        {
            dbEntities.Jobs.Add(job);
            dbEntities.SaveChanges();
        }
        public void EditJob(Job data)
        {
            dbEntities.Entry<Job>(data).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();

        }
        public Job GetJobById(int id)
        {
            Job job = dbEntities.Jobs.Find(id);
            return job;
        }
        public void DeleteJob(int id)
        {
            Job job = dbEntities.Jobs.Find(id);
            dbEntities.Jobs.Remove(job);
            dbEntities.SaveChanges();

        }
        public List<Job> GetMyJobs(int id)
        {
            var jobs = dbEntities.Jobs.Where(item=>item.Jobproviderid==id).ToList();
            return jobs;
        }
        



    }
}