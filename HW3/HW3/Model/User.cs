using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Model
{
    public enum OccupationType
    {
        Employee,
        Subcontractor,
        Client,
        Other
    }

    [Serializable]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        
        [Required(ErrorMessage="Email Address is required")]
        [EmailAddress(ErrorMessage="Please use correct Email address format xxx@xxx.xx")]
        public string Email{ get; set;}

        [Required(ErrorMessage="FirstName is required")]
        [StringLength(30, ErrorMessage="FirstName must be 30 characters or less")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Middle Initial is required")]
        [StringLength(30, ErrorMessage="Middle Initial must be 30 characters or less")]
        public string MiddleInit { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(30,ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Occupation is required")]
        public OccupationType Occupation { get; set; }

        public virtual List<Project> CreatedProjects { get; set; }

        public virtual List<UserActivity> UserActivities { get; set; }

        public virtual List<UserEntry> UserEntries { get; set; }

        public User(){  }

        //public OccupationType ParseEnum<Occupation>(string value)
    }
}
