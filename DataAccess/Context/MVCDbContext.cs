using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MVCDbContext : DbContext
    {

        public MVCDbContext() : base("MVCDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MVCDbContext, DataAccess.Migrations.Configuration>());
            //Database.CreateIfNotExists();
        }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DietaryRequirement> DietaryRequirements { get; set; }
        public DbSet<Models.Delegate> Delegates { get; set; }
        public DbSet<DelegateAddress> DelegateAddresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<DelegateTraining> DelegateTrainings { get; set; }
        public DbSet<CourseTraining> CourseTrainings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}

