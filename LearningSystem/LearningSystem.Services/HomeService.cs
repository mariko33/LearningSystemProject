using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class HomeService:Service, IHomeService
    {
        
        public IEnumerable<CourseVm> GetAllCourses()
        {
            var courses = this.Context.Courses;
            IEnumerable<CourseVm> coursesVm = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVm>>(courses);
            return coursesVm;

        }
    }
}
