using CookHiring.Data;
using CookHiring.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Controllers
{
    public class JobProviderController : Controller
    {
        public UserRepository userRepository;
        public JobRepository jobRepository;
        public  JobSeekerProfileRepository jobSeekerProfileRepository;
        public AppliedJobsRepository appliedJobsRepository;


        public JobProviderController()
        {
            userRepository = new UserRepository();
            jobRepository= new JobRepository();
            jobSeekerProfileRepository = new JobSeekerProfileRepository();
            appliedJobsRepository = new AppliedJobsRepository();
        }
        // GET: JobProvider
        public ActionResult Dashboard()
        {
            var jobs = jobRepository.GetJobs();
            return View(jobs);
        }
        public ActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddJob(Job job)
        {
            jobRepository.AddJob(job);
            return RedirectToAction("Dashboard");
        }
        public ActionResult GetMyjobs(int id=1)
       {
           var myJobs=  jobRepository.GetMyJobs(id);
            return View(myJobs);
        }
        public ActionResult GetAppliedCandidates(int id = 1)
        {
            var Candidates = jobSeekerProfileRepository.GetAppliedCandidates(id);
            return View(Candidates);
        }
        public ActionResult Accept(int id,int jobId)
        {
            appliedJobsRepository.Accept(id, jobId);
            return RedirectToAction("GetAppliedCandidates");
        }
        public ActionResult Decline(int id, int jobId)
        {
            appliedJobsRepository.Decline(id, jobId);
            return RedirectToAction("GetAppliedCandidates");

        }
    }
    }
