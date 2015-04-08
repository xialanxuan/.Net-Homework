using HW3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new WebSiteContext()) 
            {
                Console.WriteLine("This data model is complicated!!");
                //LoadData from all.xml
                LoadData(db);

                //query the tables
                var query = from row in db.Visitors
                            select row;
                Console.WriteLine("Visitors");
                foreach (var item in query)
                {
                    Console.WriteLine("{0}",item.IP);
                }
                Console.WriteLine();

                Console.WriteLine("Users");
                var query0 = from row in db.Users
                            select row;
                foreach (var item in query0)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", 
                        item.UserId, item.FirstName, item.MiddleInit, item.LastName
                        , item.Occupation);
                }
                Console.WriteLine();
                Console.WriteLine("Projects");
                var query1 = from row in db.Projects
                             select row;
                foreach (var item in query1)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                                      item.ProjectId, item.Name, item.Description, item.Archived, item.CreatorId);
                }
                Console.WriteLine();
                Console.WriteLine("Activities");
                var query2 = from row in db.Activities
                             select row;
                foreach (var item in query2)
                {
                     Console.WriteLine("{0}, {1}, {2}",
                                    item.ActivityId, item.Description, item.Type);
                }
                Console.WriteLine();
                Console.WriteLine("ProjectActivities");
                var query3 = from row in db.ProjectActivities
                             select row;
                foreach (var item in query3)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}",
                                   item.ProjectActivityId,item.ActivityId, item.ProjectId, item.TimeSpent);
                }
                Console.WriteLine();
                Console.WriteLine("UserEntries");
                var query4 = from row in db.UserEntries
                             select row;
                foreach (var item in query4)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                   item.UserEntryId, item.UserId, item.ProjectId,
                         item.ActivityId, item.HourlyCost, item.HourlyBillRate, item.Billable);
                }
                Console.WriteLine();
                Console.WriteLine("UserActivities");
                var query5 = from row in db.UserActivities
                             select row;
                foreach (var item in query5)
                {
                    Console.WriteLine("{0}, {1}, {2}",
                                   item.UserActivityId, item.ActivityId, item.UserId);
                }
                Console.WriteLine();
                Console.WriteLine("TimeEntries");
                var query6 = from row in db.TimeEntries
                             select row;
                foreach (var item in query6)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",
                            item.TimeEntryId,           
                        item.UserEntryId, item.ProjectId,
                         item.Description, item.StartTime, item.EndTime);
         
                }
                Console.Read();
            }

        }

        /// <summary>
        /// Load xml format data into database
        /// </summary>
        /// <param name="db"></param>
        public static void LoadData(WebSiteContext db)
        {
            var visitorss = XDocument.Load("all.xml").Element("All").Descendants("Visitor");
            foreach (var visitor in visitorss) 
            {
                Visitor vi = new Visitor();
                vi.IP = visitor.Element("IP").Value;
                db.Visitors.Add(vi);
            }

            var users = XDocument.Load("all.xml").Element("All").Descendants("User");
            foreach (var user in users)
            {
                User us = new User();
                
                us.UserId = Convert.ToInt32(user.Element("UserId").Value);
                us.Email = user.Element("Email").Value;
                us.FirstName = user.Element("FirstName").Value;
                us.MiddleInit = user.Element("MiddleInit").Value;
                us.LastName = user.Element("LastName").Value;
                string occ = user.Element("Occupation").Value;
                us.Occupation = (OccupationType) Enum.Parse(typeof(OccupationType),occ);
                db.Users.Add(us);
            }

            var projects = XDocument.Load("all.xml").Element("All").Descendants("Project");
            foreach (var project in projects)
            {
                Project pro = new Project();
                pro.ProjectId = Convert.ToInt32(project.Element("ProjectId").Value);
                pro.Name = project.Element("Name").Value;
                pro.Description = project.Element("Description").Value;
                pro.Archived = Convert.ToBoolean(project.Element("Archived").Value);
                pro.CreatorId = Convert.ToInt32(project.Element("CreatorId").Value);
                db.Projects.Add(pro);
            }

            var activities = XDocument.Load("all.xml").Element("All").Descendants("Activity");
            foreach (var activity in activities)
            {
                Activity act = new Activity();
                act.ActivityId= Convert.ToInt32(activity.Element("ActivityId").Value);
                act.Description = activity.Element("Description").Value;
                act.Type = (ActivityType) Enum.Parse(typeof(ActivityType), activity.Element("Type").Value);
                db.Activities.Add(act);
            }

            var projectactivities = XDocument.Load("all.xml").Element("All").Descendants("ProjectActivity");
            foreach (var projectactivity in projectactivities)
            {
                ProjectActivity pa = new ProjectActivity();
                pa.ProjectActivityId = Convert.ToInt32(projectactivity.Element("ProjectActivityId").Value);
                pa.ActivityId = Convert.ToInt32(projectactivity.Element("ActivityId").Value);
                pa.ProjectId = Convert.ToInt32(projectactivity.Element("ProjectId").Value);
                pa.TimeSpent = TimeSpan.Parse(projectactivity.Element("TimeSpent").Value);
                db.ProjectActivities.Add(pa);
            }
            var userentities = XDocument.Load("all.xml").Element("All").Descendants("UserEntry");
            foreach (var userentity in userentities)
            {
                UserEntry ue = new UserEntry();
                ue.UserEntryId = Convert.ToInt32(userentity.Element("UserEntryId").Value);
                ue.UserId = Convert.ToInt32(userentity.Element("UserId").Value);
                ue.ProjectId = Convert.ToInt32(userentity.Element("ProjectId").Value);
                ue.ActivityId = Convert.ToInt32(userentity.Element("ActivityId").Value);
                ue.HourlyCost = Convert.ToDouble(userentity.Element("HourlyCost").Value);
                ue.HourlyBillRate = Convert.ToDouble(userentity.Element("HourlyBillRate").Value);
                ue.Billable = Convert.ToBoolean(userentity.Element("Billable").Value);

                db.UserEntries.Add(ue);
            }
            var useractivities = XDocument.Load("all.xml").Element("All").Descendants("UserActivity");
            foreach (var useractivity in useractivities)
            {
                UserActivity ua = new UserActivity();
                ua.UserActivityId = Convert.ToInt32(useractivity.Element("UserActivityId").Value);
                ua.ActivityId = Convert.ToInt32(useractivity.Element("ActivityId").Value);
                ua.UserId = Convert.ToInt32(useractivity.Element("UserId").Value);
                db.UserActivities.Add(ua);
            }
            var timeentries = XDocument.Load("all.xml").Element("All").Descendants("TimeEntry");
            foreach (var timeentry in timeentries)
            {
                TimeEntry te = new TimeEntry();
                te.TimeEntryId = Convert.ToInt32(timeentry.Element("TimeEntryId").Value);
                te.UserEntryId = Convert.ToInt32(timeentry.Element("UserEntryId").Value);
                te.ProjectId = Convert.ToInt32(timeentry.Element("ProjectId").Value);
                te.Description = timeentry.Element("Description").Value;
                te.StartTime = Convert.ToDateTime(timeentry.Element("StartTime").Value);
                te.EndTime = Convert.ToDateTime(timeentry.Element("EndTime").Value);
                db.TimeEntries.Add(te);
            }
            db.SaveChanges();
        }
    }
}
