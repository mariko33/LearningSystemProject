using LearningSystem.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningSystem.Data.LearningSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LearningSystem.Data.LearningSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var store=new RoleStore<IdentityRole>(context);
                var manager=new RoleManager<IdentityRole>(store);
                var role=new IdentityRole("Student");
                manager.Create(role);

            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store=new RoleStore<IdentityRole>(context);
                var manager=new RoleManager<IdentityRole>(store);
                var role=new IdentityRole("Admin");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Trainer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("BlogAuthor");
                manager.Create(role);
            }

            context.Courses.AddOrUpdate(course=>course.Name,new Course[]
            {
                new Course()
                {
                    Name = "Programming Basic - March 2016",
                    Description = "Курсът дава начални умения по програмиране, необходими за започване на обучението в СофтУни.",
                    StartDate = new DateTime(2016,03,03),
                    EndDate = new DateTime(2016,05,03)
                },
                 new Course()
                {
                    Name = "Software Technologies - February 2017",
                    Description = "Курсът дава начални умения по най-използваните технологии за програмиране.",
                    StartDate = new DateTime(2017,3,25),
                    EndDate = new DateTime(2017,5,30)
                },
                  new Course()
                {
                    Name = "Java OOP Advanced - September 2017",
                    Description = "Курсът дава надгражда основните знания за езика JAVA, като развива знанията за обектно орентирано програмиране.",
                    StartDate = new DateTime(2017,9,1),
                    EndDate = new DateTime(2017,10,28)
                },
                   new Course()
                {
                    Name = "C# MVC Frameworks-ASP.Net - June 2017",
                    Description = "Курсът дава добри познания как се използва една от най-известните технологии за изграждане на сайтове.",
                    StartDate = new DateTime(2017,6,1),
                    EndDate = new DateTime(2017,7,30)
                },
            });
        }
    }
}
