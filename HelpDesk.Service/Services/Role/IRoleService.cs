using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.Role
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAll();
        Task InitRoles();
    }
}
