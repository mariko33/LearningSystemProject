using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Web.Services.Description;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Attributes;

namespace LearningSystem.Web.Controllers
{
    
    
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service=service;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<CourseVm> coursesVm = this.service.GetAllCourses();
            return this.View(coursesVm);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}