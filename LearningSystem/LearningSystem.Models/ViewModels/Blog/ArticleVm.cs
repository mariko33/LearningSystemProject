using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.EntityModels;

namespace LearningSystem.Models.ViewModels.Blog
{
   public class ArticleVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public ArticleAuthorVm Author { get; set; }
    }
}
