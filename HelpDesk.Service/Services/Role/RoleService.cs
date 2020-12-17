using AutoMapper;
using HelpDesk.Data;
using HelpDesk.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public RoleService(ApplicationDbContext Db,IMapper mapper,RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _Db = Db;
            _mapper = mapper;
        }

        public List<RoleViewModel> GetAll()
        {
            var roles = _Db.Roles.ToList();
            var rolesVm = _mapper.Map<List<IdentityRole>, List<RoleViewModel>>(roles);
            return rolesVm;
        }

        public async Task InitRoles()
        {
            var roles = new List<string>();
            roles.Add("Admin");
            roles.Add("HelpDisk");
            roles.Add("Employee");

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }


    }
}
