using CookHiring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookHiring.UI.Models
{
    public class JobSeekerDTO
    {
        public int JobSeekerId { get; set; }
        
        public string PersonName { get; set; }
       
        public string PersonEmail { get; set; }
        
        public string PersonExp { get; set; }
        
        public string PersonAddress { get; set; }
        
        public string PersonPhone { get; set; }
        public string isGotJob { get; set; }

        public int Jobid { get; set; }
    }
}