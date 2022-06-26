using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookHiring.UI.Models
{
    public class JobsDTO
    {
        public int JobId { get; set; }
              
        public string JobDescription { get; set; }
       
        public string JobLocation { get; set; }
       
        public DateTime? FromDate { get; set; }
    
        public DateTime? ToDate { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public string WagePerDay { get; set; }
      
        public string JobStatus { get; set; }
       
        public int? Jobproviderid { get; set; }
        public string isGotJob { get; set; }

    }
}