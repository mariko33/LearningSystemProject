using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Models.BindingModels.Admin;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;
       

        public AdminController(IAdminService service)
        {
            this.service=service;
          
        }

        // GET: Admin/Admin
        [Route]
        public ActionResult Index()
        {
            AdminPageVm vm = this.service.GetAdminPage();
            return this.View(vm);
        }

        [HttpGet]
        [Route("courese/add")]
        public ActionResult AddCourse()
        {
            return this.View();
        }

        [HttpPost]
        [Route("courese/add")]
        public ActionResult AddCourse(AddCourseBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddCourse(bm);
               return this.RedirectToAction("Index");
            }
            else
            {
                return this.View();
            }
            
        }


        [HttpGet]
        [Route("courses/{id}/edit")]
        public ActionResult EditCourse(int id)
        {
            return this.View();
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            return this.View();

        }
    }
}