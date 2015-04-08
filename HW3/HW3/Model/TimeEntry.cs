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
    public class TimeEntry
    {
        public TimeEntry() { }

        public int TimeEntryId { get; set; }

        [Required(ErrorMessage = "UserEntry id is required")]
        public int UserEntryId { get; set; }

        public virtual UserEntry UserEntry { get; set; }

        [Required(ErrorMessage = "Project id is required")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(5000, ErrorMessage = "Description must be 5000 characters or less")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]
        public DateTime EndTime { get; set; }

    }
}
