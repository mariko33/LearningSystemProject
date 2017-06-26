using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
   public class CoursesService:Service, ICoursesService
   {
        public DetailsCourseVm GetDetails(int id)
        {
            Course course = this.Context.Courses.Find(id);
            if (course == null)
            {
                return null;
            }

            DetailsCourseVm vm = Mapper.Map<Course, DetailsCourseVm>(course);
            return vm;
        }
    }
}
