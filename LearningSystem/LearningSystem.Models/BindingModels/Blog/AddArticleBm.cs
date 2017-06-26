using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace LearningSystem.Models.BindingModels.Blog
{
   public class AddArticleBm
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
       
    }
}
