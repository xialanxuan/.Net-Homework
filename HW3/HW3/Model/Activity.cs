using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Model
{
    public enum ActivityType { Consulting, Development, Accounting, Other }

    [Serializable]
    public class Activity
    {
        public int ActivityId { get; set; }

        [Required]
        [StringLength(2000,ErrorMessage="The description should be less then 2000 characters")]
        public string Description { get; set; }

        public ActivityType Type { get; set; }

        public virtual List<UserActivity> Users { get; set; }

        public virtual List<ProjectActivity> Projects { get; set; }

        public virtual List<UserEntry> UserEntries { get; set; } 
        public Activity() { }
    }
}
