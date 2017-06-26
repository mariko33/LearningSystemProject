using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.Users;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Web.Controllers
{

    [Authorize(Roles = "Student")]
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service=service;
        }



        [HttpPost]
        [Route("enroll")]
        public ActionResult Enroll(int courseId)
        {
            string userName = this.User.Identity.Name;
            Student student = this.service.GetCurrentStudent(userName);
            this.service.EnrollStudentInCourse(courseId, student);
            return this.RedirectToAction("Profile");
        }

        [HttpGet]
        [Route("profile")]
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;
           ProfileVm vm= this.service.GetProfileVm(userName);
            return this.View(vm);

        }

        


        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditUserVm vm = this.service.GetEditVm(userName);
            return this.View(vm);

        }


        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUserBm bind)
        {
            if (ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditUser(bind, currentUserName);

                return this.RedirectToAction("Profile");
            }

            //string userName =this.User.Identity.Name;
            //EditUserVm vm = this.service.GetEditVm(userName);
            //return this.View(vm);

            return this.RedirectToAction("Edit");
        }
    }
}