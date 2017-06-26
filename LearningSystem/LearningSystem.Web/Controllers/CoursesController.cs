using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = "Student")]
    [RoutePrefix("courses")]
    public class CoursesController : Controller
    {
        private ICoursesService service;
        public CoursesController(ICoursesService service)
        {
            this.service=service;
        }

        [Route("details/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailsCourseVm vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }
            return this.View(vm);
        }

       
    }
}