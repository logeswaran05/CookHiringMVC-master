using CookHiring.Data;
using CookHiring.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Controllers
{
    public class JobSeekerController : Controller
    {
        public UserRepository userRepository;
        public JobRepository jobRepository;
        public JobSeekerProfileRepository jobSeekerProfileRepository;
        public AppliedJobsRepository appliedJobsRepository;
        public ReviewRepository reviewRepository;

        public JobSeekerController()
        {
            userRepository = new UserRepository();
            jobRepository = new JobRepository();
            jobSeekerProfileRepository = new JobSeekerProfileRepository();
            appliedJobsRepository = new AppliedJobsRepository();
            reviewRepository = new ReviewRepository();
        }
        // GET: JobSeeker
        public ActionResult Dashboard()
        {
            var jobs = jobRepository.GetJobs();
            return View(jobs);
        }
         public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Id,JobSeekerProfile profile)
        {
            Appliedjobs data= new Appliedjobs();
            data.JobId = Convert.ToInt32(Id);
            profile.JobSeekerId = 2;
            data.JobSeekerId = profile.JobSeekerId;
            data.isGotjob = "available";
            jobSeekerProfileRepository.AddJobSeekersProfile(profile);
            appliedJobsRepository.AddAppliedJobs(data);
            return RedirectToAction("Dashboard");
        } 
        public ActionResult AppliedJobs(int id=2)
        {
            var data=appliedJobsRepository.AppliedjobsList(id);
            return View(data);
        }
        public ActionResult GetReview(int id=2)
        {
            var data = reviewRepository.GetReview( id);
            return View(data);
        }
        public ActionResult JobDetails(int id)
        {
            var data= jobRepository.GetJobById(id);
            return View(data);
        }
        public ActionResult Remove(int id, int jobSeekerId=2)
        {
            appliedJobsRepository.Remove(id,jobSeekerId);
            return RedirectToAction("AppliedJobs");
        }
            
    }
}