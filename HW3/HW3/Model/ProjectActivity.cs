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
    public class ProjectActivity
    {
        public int ProjectActivityId { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required(ErrorMessage = "Estimate total time is required")]

        public TimeSpan TimeSpent { get; set; }

        public ProjectActivity() { }
    }
}
