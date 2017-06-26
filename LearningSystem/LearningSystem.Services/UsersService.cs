using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.Users;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
   public class UsersService:Service, IUsersService
   {
        public Student GetCurrentStudent(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            Student student = this.Context.Students.FirstOrDefault(s => s.User.Id == user.Id);
            return student;
        }

        public void EnrollStudentInCourse(int courseId, Student student)
        {
            Course wantedCourse = this.Context.Courses.Find(courseId);
            student.Courses.Add(wantedCourse);
            this.Context.SaveChanges();
        }

        public ProfileVm GetProfileVm(string userName)
        {
           
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            ProfileVm vm = Mapper.Map<ApplicationUser, ProfileVm>(currentUser);
            Student currentStudent = this.Context.Students.FirstOrDefault(student => student.User.UserName == userName);
            vm.EnroledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseVm>>(currentStudent.Courses);
            return vm;
        }

        public EditUserVm GetEditVm(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditUserVm vm = Mapper.Map<ApplicationUser, EditUserVm>(user);
            return vm;

        }

        public void EditUser(EditUserBm bind, string currentUserName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName==currentUserName);
            user.Name = bind.Name;
            user.Email = bind.Email;
            this.Context.SaveChanges();

        }


       
    }
}
