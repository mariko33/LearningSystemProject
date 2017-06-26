using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace LearningSystem.Models.BindingModels.Users
{
   public class EditUserBm
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
