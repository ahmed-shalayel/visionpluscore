using HelpDesk.Data.Dto;
using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Service.Services.Department
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> GetAll();

        int Save(DepartmentDto entity);

        void Delete(int id);

        DepartmentDto Get(int id);
    }
}
