using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW3.Model
{
    [Serializable]
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [StringLength(40, ErrorMessage="Porject name must be 40 characters or less")]
        public string Name { get; set; }

        [StringLength(5000, ErrorMessage = "Description must be 5000 characters or less")]
        public string Description { get; set; }

        [Required(ErrorMessage="Archived is required")]
        public bool Archived { get; set; }

        [XmlIgnore]
        [Required(ErrorMessage="Creator id is required")]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual List<ProjectActivity> CurrentActivities { get; set; }

        public virtual List<ProjectActivity> FinishedActivities { get; set; }

        public virtual List<UserEntry> UserEntries { get; set; }

        public virtual List<TimeEntry> TimeEntries { get; set; }

        public Project()
        {
            Archived = false;
            CurrentActivities = new List<ProjectActivity>();
            FinishedActivities = new List<ProjectActivity>();
            UserEntries = new List<UserEntry>();
            TimeEntries = new List<TimeEntry>();
        }

    }
}
