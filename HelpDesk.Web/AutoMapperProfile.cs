using AutoMapper;
using HelpDesk.Data.Dto;
using HelpDesk.Data.Model;
using HelpDesk.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ForMember(x => x.AdminName,x => x.MapFrom(x => x.Admin.FullName));
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Ticket, TicketViewModel>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketTimeLine, TimeLineViewModel>();
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<Data.Model.TicketFiles, TicketFilesViewModel>();
        }

    }
}
