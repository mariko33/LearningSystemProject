using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.Users
{
   public class ProfileVm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<UserCourseVm> EnroledCourses { get; set; }
    }
}
