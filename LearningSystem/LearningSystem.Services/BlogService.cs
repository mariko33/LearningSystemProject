using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
   public class BlogService:Service, IBlogService
   {
        public IEnumerable<ArticleVm> GetAllArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles;
            IEnumerable<ArticleVm> vms = Mapper.Map<IEnumerable<Article>,IEnumerable<ArticleVm>>(articles);
            return vms;

        }

        public void AddNewArticle(AddArticleBm bind, string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            Article article=new Article()
            {
                Author = currentUser,
                Content = bind.Content,
                Title = bind.Title,
                PublishDate = DateTime.Today
            };
            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }
    }
}
