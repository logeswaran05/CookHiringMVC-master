using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace CookHiring.Data
{
    public partial class JobSeekerProfile
    {
        [Required]
        [Key,ForeignKey("User")]
        public int JobSeekerId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        // -------------------------------------
        [Required]
        [StringLength(50)]
        public string PersonName { get; set; }
        [Required]
        [StringLength(50)]
        public string PersonEmail { get; set; }
        [Required]
        [StringLength(2)]
        public string PersonExp { get; set; }
        [Required]
        [StringLength(100)]
        public string PersonAddress { get; set; }
        [Required]
        [StringLength(10)]
        public string PersonPhone { get; set; }
    }
}
