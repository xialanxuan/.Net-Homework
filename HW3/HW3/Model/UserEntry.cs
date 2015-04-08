using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Model
{
    [Serializable]
    public class UserEntry
    {
        public int UserEntryId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }   
        [Required(ErrorMessage="Hourly cost is required")]
        public double HourlyCost { get; set; }

        [Required(ErrorMessage="Hourly bill rate is required")]
        public double HourlyBillRate { get; set; }

        [Required(ErrorMessage="Billable or not is required")]
        public bool Billable { get; set; }

        public virtual List<TimeEntry> TimeEntries { get; set; }

        public UserEntry() 
        {
            TimeEntries = new List<TimeEntry>();
        }
    }
}
