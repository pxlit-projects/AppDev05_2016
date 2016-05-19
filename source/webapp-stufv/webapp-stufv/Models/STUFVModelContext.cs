using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models
{
    public class STUFVModelContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<DesDriver> DesDrivers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTypes> EventTypes { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Guideline> Guidelines { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Logout> Logouts { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<ArticleVote> ArticleVotes { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<ProfileSettings> ProfileSettings{ get; set; }
        public object Event { get; internal set; }

        public STUFVModelContext() {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<STUFVModelContext> ( null );
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}