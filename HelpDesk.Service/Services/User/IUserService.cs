using HelpDesk.Data.Dto;
using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HelpDesk.Service
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();
        Task<bool> Create(UserDto dto);

        void Delete(string id);

        UserDto Get(string id);

        void Update(UserDto dto);
    }
}
