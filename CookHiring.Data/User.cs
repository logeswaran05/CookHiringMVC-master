using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CookHiring.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        [StringLength(30)]
        public string password { get; set; }
        [Required]
        [StringLength(50)]
        public string username { get; set; }
        [Required]
        [StringLength(10)]
        public string mobileNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string userrole { get; set; }

        // Navigation Property
        public ICollection<Job> Jobs { get; set; }
        [JsonIgnore]
        public virtual JobSeekerProfile Profile{get; set;}
        public virtual ICollection<Appliedjobs> Appliedcandidates{get; set;}
        public  ICollection<Review> review {get; set;}
       
    }
}
