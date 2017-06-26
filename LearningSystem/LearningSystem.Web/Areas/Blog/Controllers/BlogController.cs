using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [RouteArea("blog")]
    [RoutePrefix("blog")]
    
    public class BlogController : Controller
    {
        private IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }


        [Route("allarticles")]
        [Authorize(Roles = "Student,BlogAuthor")]
        [HttpGet]
        public ActionResult AllArticles()
        {
            IEnumerable<ArticleVm> vms = this.service.GetAllArticles();
            return this.View(vms);
        }



        [HttpGet]
        [Authorize(Roles = "BlogAuthor")]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }



        [HttpPost]
        [Authorize(Roles = "BlogAuthor")]
        [Route("add")]
        public ActionResult Add(AddArticleBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string userName = this.User.Identity.Name;
                this.service.AddNewArticle(bind, userName);
                return this.RedirectToAction("AllArticles");
            }
            return this.View();
        }
  

    
}
}