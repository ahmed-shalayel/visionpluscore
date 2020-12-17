using AutoMapper;
using HelpDesk.Data;
using HelpDesk.Data.Dto;
using HelpDesk.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _Db;
        private readonly UserManager<Data.Model.User> _userManager;
        private readonly IMapper _Mapper;

        public UserService(UserManager<Data.Model.User> userManager,ApplicationDbContext Db, IMapper Mapper)
        {
            _Db = Db;
            _Mapper = Mapper;
            _userManager = userManager;
        }

        public List<UserViewModel> GetAll()
        {
            var data = _Db.Users.Where(x => !x.IsDelete).ToList();
            var users = _Mapper.Map<List<Data.Model.User>, List<UserViewModel>>(data);
            return users;
        }

        public async Task<bool> Create(UserDto dto)
        {
            var user = _Mapper.Map<UserDto, Data.Model.User>(dto);
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, "Ahmed11$");
            return result.Succeeded;
        }


        public void Update(UserDto dto)
        {
            var user = _Db.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);

            var updatedUser = _Mapper.Map<UserDto, Data.Model.User>(dto, user);

            _Db.Users.Update(updatedUser);
            _Db.SaveChanges();
        }
        public void Delete(string id)
        {
            var user = _Db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            user.IsDelete = true;
            _Db.Users.Update(user);
            _Db.SaveChanges();
        }

        public UserDto Get(string id)
        {
            var user = _Db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            var userDto = _Mapper.Map<Data.Model.User, UserDto>(user);
            return userDto;
        }

    }
}
