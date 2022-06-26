using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace CookHiring.Data
{
    
    public partial class Job
    {
        [Required]
        [Key]
        public int JobId { get; set; }
        [JsonIgnore]
        public Review review { get; set; }
        // ----------------------------------------
        [StringLength(50)]
        [Required]
        public string JobDescription { get; set; }
        [Required]
         [StringLength(30)]
        public string JobLocation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        [Required]
         [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]

        public string WagePerDay { get; set; }
        [Required]
        public string JobStatus { get; set; }
        // ----------------------------------------
        [ForeignKey("User")]
        public int? Jobproviderid { get; set; }
        [JsonIgnore]
        public  User User { get; set; }
        // ----------------------------------------
        public ICollection<Appliedjobs> Appliedcandidates{get; set;}

        

    }
}
