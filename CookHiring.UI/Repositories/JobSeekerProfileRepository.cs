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
    public class JobSeekerProfileRepository
    {
        public ApplicationDbContext dbEntities;
        public JobSeekerProfileRepository()
        {
            dbEntities = new ApplicationDbContext();
        }
        public List<JobSeekerDTO> GetAppliedCandidates(int id)
        {
           List<JobSeekerDTO> applications=new List<JobSeekerDTO>();
            var candidates = ( from a in dbEntities.AppliedJobs.Where(item => item.JobId == id && item.isGotjob!="false" ) join b in dbEntities.JobSeekersProfile on a.JobSeekerId equals b.JobSeekerId select new{ b.JobSeekerId,b.PersonPhone,b.PersonName,b.PersonEmail,b.PersonExp,b.PersonAddress,a.isGotjob } ).ToList();
            foreach(var candidate in candidates)
            {
                JobSeekerDTO jobseeker = new JobSeekerDTO();
                jobseeker.JobSeekerId = candidate.JobSeekerId;
                jobseeker.PersonName=candidate.PersonName;
                jobseeker.PersonEmail = candidate.PersonEmail;
                jobseeker.PersonExp = candidate.PersonExp;
                jobseeker.PersonAddress = candidate.PersonAddress;
                jobseeker.PersonPhone = candidate.PersonPhone;
                jobseeker.PersonEmail = candidate.PersonEmail;
                jobseeker.isGotJob = candidate.isGotjob;
                jobseeker.Jobid = id;
                applications.Add(jobseeker);
            }

            return applications; 
        }
        public JobSeekerProfile GetJobSeekersProfileById(int id)
        {
            JobSeekerProfile profile = dbEntities.JobSeekersProfile.Find(id);
            return profile;
        }
        public void AddJobSeekersProfile(JobSeekerProfile data)
        {
            if (dbEntities.JobSeekersProfile.Any(e => e.JobSeekerId == data.JobSeekerId))

            {
                dbEntities.JobSeekersProfile.Attach(data);
                dbEntities.Entry<JobSeekerProfile>(data).State = EntityState.Modified;
            }
            else
            {
                dbEntities.JobSeekersProfile.Add(data);

            }
            dbEntities.SaveChanges();
        }
        public void EditJobSeekersProfile(JobSeekerProfile data)
        {
            dbEntities.Entry<JobSeekerProfile>(data).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();

        }
        public void DeleteJobSeekersProfile(int id)
        {
            JobSeekerProfile profile =dbEntities.JobSeekersProfile.Find(id);
            dbEntities.JobSeekersProfile.Remove(profile);
            dbEntities.SaveChanges();

        }


    }
}