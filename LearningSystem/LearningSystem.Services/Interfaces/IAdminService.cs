using System.Collections.Generic;
using LearningSystem.Models.BindingModels.Admin;
using LearningSystem.Models.ViewModels.Admin;

namespace LearningSystem.Services.Interfaces
{
    public interface IAdminService
    {
        AdminPageVm GetAdminPage();


        void AddCourse(AddCourseBm bm);
    }
}