using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Models.BindingModels.Admin;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningSystem.Services
{
   public class AdminService:Service, IAdminService
   {
        public AdminPageVm GetAdminPage()
        {
            AdminPageVm page=new AdminPageVm();
            IEnumerable<Course> courses = this.Context.Courses;
            IEnumerable<Student> students = this.Context.Students;
            IEnumerable<CourseVm> courseVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVm>>(courses);
            IEnumerable<AdminPageUserVm> userVms =
                Mapper.Map<IEnumerable<Student>, IEnumerable<AdminPageUserVm>>(students);
            page.Users = userVms;
            page.Courses = courseVms;
            return page;

        }

       public void AddCourse(AddCourseBm bm)
       {
          // Course course = Mapper.Map<AddCourseBm, Course>(bm);
          Course course=new Course()
          {
              Name = bm.Name,
              Description = bm.Description,
              EndDate = bm.EndDate,
              StartDate = bm.StartDate
          };
           this.Context.Courses.Add(course);
           this.Context.SaveChanges();

       }
   }
}
