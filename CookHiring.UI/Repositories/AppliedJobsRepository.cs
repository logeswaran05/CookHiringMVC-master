using CookHiring.Data;
using CookHiring.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CookHiring.UI.Repositories
{
    public class AppliedJobsRepository
    {
        public ApplicationDbContext dbEntities;
        public AppliedJobsRepository()
        {
            dbEntities = new ApplicationDbContext();
        }
        public void AddAppliedJobs( Appliedjobs data)
        {
           
            
            if (dbEntities.AppliedJobs.Any(e=>e.JobId==data.JobId && e.JobSeekerId==data.JobSeekerId))
            {

                return;
            }
            else
            {
                dbEntities.AppliedJobs.Add(data);
               
            }
            dbEntities.SaveChanges();


        }
        public void Accept(int id,int jobId)
        {
           var data = dbEntities.AppliedJobs.Where(item => item.JobId == jobId && item.JobSeekerId == id).ToArray();
            data[0].isGotjob = "true";
           
            dbEntities.SaveChanges();
        }
        public void Decline(int id, int jobId)
        {
            var data = dbEntities.AppliedJobs.Where(item => item.JobId == jobId && item.JobSeekerId == id).ToArray();
            data[0].isGotjob = "false";
            dbEntities.Entry<Appliedjobs>(data[0]).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
        }
        public List<JobsDTO> AppliedjobsList(int id)
        {
            var jobs= from a in dbEntities.AppliedJobs.Where(item=>item.JobSeekerId==id)
                      join b in dbEntities.Jobs on a.JobId equals b.JobId
                      select new { a.isGotjob, b };
            List<JobsDTO> data = new List<JobsDTO>();
            foreach(var job in jobs)
            {
                JobsDTO ob = new JobsDTO();
                ob.isGotJob = job.isGotjob;
                ob.JobId = job.b.JobId;
                ob.JobLocation = job.b.JobLocation;
                ob.JobDescription = job.b.JobDescription;
                ob.FromDate = job.b.FromDate;
                ob.WagePerDay = job.b.WagePerDay;
                ob.ToDate = job.b.ToDate;
                ob.JobStatus = job.b.JobStatus;
                ob.PhoneNumber = job.b.PhoneNumber;
                ob.Jobproviderid = job.b.Jobproviderid;
                data.Add(ob);

            }
            return data;
        }
        public void Remove(int jobId, int jobSeekerId)
        {
            var data = dbEntities.AppliedJobs.Where(item => item.JobId == jobId && item.JobSeekerId == jobSeekerId).FirstOrDefault();
            dbEntities.AppliedJobs.Remove(data);
            dbEntities.SaveChanges();
        }
    }
}