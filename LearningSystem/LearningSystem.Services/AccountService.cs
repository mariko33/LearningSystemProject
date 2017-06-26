using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.EntityModels;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
   public class AccountService :Service, IAccountService
   {
        public void CreateStudent(ApplicationUser user)
        {
            Student student=new Student();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            student.User = currentUser;
            this.Context.Students.Add(student);
            this.Context.SaveChanges();


        }
    }
}
