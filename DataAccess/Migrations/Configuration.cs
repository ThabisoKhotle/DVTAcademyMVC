namespace DataAccess.Migrations
{
    using DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.MVCDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Context.MVCDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<Course> courses = new List<Course>();

            courses.Add(new Course() { ID = 1, Code = "DM", Name = "Data Management", Description = "Data Management -Provide one paragraph" });
            courses.Add(new Course() { ID = 2, Code = "DD", Name = "SQL 2016 Database Development", Description = "SQL 2016 Database Development" });
            courses.Add(new Course() { ID = 3, Code = "DA", Name = "SQL 2016 Database Administration", Description = "SQL 2016 Database Administration" });
            courses.Add(new Course() { ID = 4, Code = " O365", Name = "Office 365", Description = "Office 365" });
            courses.Add(new Course() { ID = 5, Code = "AZ", Name = "Azure ", Description = "Azure " });
            courses.Add(new Course() { ID = 6, Code = "MVC", Name = "MVC", Description = "MVC" });
            courses.Add(new Course() { ID = 7, Code = "HTML", Name = "HTML5", Description = "HTML5" });
            courses.Add(new Course() { ID = 8, Code = "JV", Name = "JavaScript", Description = "JavaScript" });
            courses.Add(new Course() { ID = 9, Code = "AN", Name = "Angular", Description = "Angular" });
            courses.Add(new Course() { ID = 10, Code = "SC", Name = "Scrum", Description = "Scrum" });

            courses.ForEach(y => context.Courses.AddOrUpdate(x => x.Code, y));

            //context.Courses.AddRange(courses);

            List<AddressType> addressTypes = new List<AddressType>();

            addressTypes.Add(new AddressType() { Type = "Physical Address" });
            addressTypes.Add(new AddressType() { Type = "Postal Address" });

            //addressTypes.ForEach(x => context.AddressTypes.AddOrUpdate(y => y.Id, x));
            addressTypes.ForEach(y => context.AddressTypes.AddOrUpdate(x => x.Type, y));

            //context.AddressTypes.AddRange(addressTypes);

            List<DietaryRequirement> dietaryRequirements = new List<DietaryRequirement>();

            dietaryRequirements.Add(new DietaryRequirement() { Requirement = "Halal" });
            dietaryRequirements.Add(new DietaryRequirement() { Requirement = "Vegetarian" });

            dietaryRequirements.ForEach(x => context.DietaryRequirements.AddOrUpdate(y => y.Requirement, x));

            //context.DietaryRequirements.AddRange(dietaryRequirements);

            List<Venue> venues = new List<Venue>();

            venues.Add(new Venue() { Name = "GiGA", Seats = 10 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });
            venues.Add(new Venue() { Name = "ABC", Seats = 20 });

            //venues.ForEach(x => context.Venues.AddOrUpdate(y => y.Name, x));

            //context.Venues.AddRange(venues);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
