using HW3.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    [Serializable]
    public class WebSiteContext : DbContext
    {
        public WebSiteContext()
        {
            Database.SetInitializer<WebSiteContext>(new DropCreateDatabaseAlways<WebSiteContext>());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ProjectActivity> ProjectActivities { get; set; }

        public DbSet<UserActivity> UserActivities { get; set; }

        public DbSet<UserEntry> UserEntries { get; set; }

        public DbSet<TimeEntry> TimeEntries { get; set; }

        /// <summary>
        /// Configure relationship using Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        
            //Configure relations
            modelBuilder.Entity<Model.Project>()
                .HasRequired<Model.User>(p => p.Creator)
                .WithMany(u => u.CreatedProjects)
                .HasForeignKey(p => p.CreatorId);

            modelBuilder.Entity<Model.UserEntry>()
                .HasRequired<Model.User>(u => u.User)
                .WithMany(u => u.UserEntries)
                .HasForeignKey(u => u.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserActivity>()
                .HasRequired<User>(ua => ua.User)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserActivity>()
                .HasRequired<Activity>(ua => ua.Activity)
                .WithMany(a => a.Users)
                .HasForeignKey(ua => ua.ActivityId);

            modelBuilder.Entity<UserEntry>()
                .HasRequired<Activity>(u => u.Activity)
                .WithMany(a => a.UserEntries)
                .HasForeignKey(u => u.ActivityId);

            modelBuilder.Entity<UserEntry>()
                .HasRequired<Project>(ue => ue.Project)
                .WithMany(p => p.UserEntries)
                .HasForeignKey(ue => ue.ProjectId);

            modelBuilder.Entity<Model.TimeEntry>()
                .HasRequired<Model.Project>(t => t.Project)
                .WithMany(p => p.TimeEntries)
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<ProjectActivity>()
                .HasRequired<Project>(pa => pa.Project)
                .WithMany(p => p.CurrentActivities)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<ProjectActivity>()
                .HasRequired<Project>(pa => pa.Project)
                .WithMany(p => p.FinishedActivities)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<ProjectActivity>()
                .HasRequired<Activity>(pa => pa.Activity)
                .WithMany(a => a.Projects)
                .HasForeignKey(pa => pa.ActivityId);

            modelBuilder.Entity<TimeEntry>()
                .HasRequired<UserEntry>(t => t.UserEntry)
                .WithMany(u => u.TimeEntries)
                .HasForeignKey(t => t.UserEntryId)
                .WillCascadeOnDelete(false);


        }
    }
}
