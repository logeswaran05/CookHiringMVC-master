using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace CookHiring.Data
{
   
    public class Appliedjobs
    {
       [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Job")]
        public int JobId { get; set; }
        [JsonIgnore]
        public Job Job {get; set;}
        //*****-----
        [Required]
        [ForeignKey("User")]
        public int JobSeekerId {get; set;}
        [JsonIgnore]
        public  User User { get; set; }

        [Required]
        public string  isGotjob {get;set;}
      
        
        
    }
}