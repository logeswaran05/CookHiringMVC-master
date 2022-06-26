using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace CookHiring.Data
{
    public class Review
    {
        [Key , ForeignKey("JobId")]
        public int Id {get; set;}
        [JsonIgnore]
        public Job JobId { get; set; }

        // ---------------------
        [Required]
        public int Rate {get; set;}

        [Required]
        public string comment {get; set; }
        // ---------------------

        [ForeignKey("jobSeeker")]
        public int jobSeekerId {get; set; }
         [JsonIgnore]
          public  User jobSeeker { get; set; }

    } 
}