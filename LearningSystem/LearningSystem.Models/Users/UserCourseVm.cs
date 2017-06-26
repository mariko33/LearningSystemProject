﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.Enums;

namespace LearningSystem.Models.Users
{
   public class UserCourseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
    }
}
