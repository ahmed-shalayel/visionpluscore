using AutoMapper;
using HelpDesk.Data;
using HelpDesk.Data.Dto;
using HelpDesk.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDesk.Service.Services.Department
{
    public class DepartmentService : IDepartmentService
    {

        private readonly ApplicationDbContext _Db;
        private readonly IMapper _Mapper;

        public DepartmentService(ApplicationDbContext Db, IMapper Mapper)
        {
            _Db = Db;
            _Mapper = Mapper;
        }

        public List<DepartmentViewModel> GetAll()
        {
           var data = _Db.Departments.Include(x => x.Admin).Where(x => !x.IsDelete).ToList();
           var departments = _Mapper.Map<List<Data.Model.Department>, List<DepartmentViewModel>>(data);
           return departments;
        }

        public int Save(DepartmentDto entity)
        {
            var department = _Mapper.Map<DepartmentDto, Data.Model.Department>(entity);
            if (entity.Id == null)
            {
               _Db.Departments.Add(department);
               return _Db.SaveChanges();
            }
          
            _Db.Departments.Update(department);
             return _Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var departement = _Db.Departments.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            departement.IsDelete = true;
            _Db.Departments.Update(departement);
            _Db.SaveChanges();
        }

        public DepartmentDto Get(int id)
        {
            var departement = _Db.Departments.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            var departementDto = _Mapper.Map<Data.Model.Department, DepartmentDto>(departement);
            return departementDto;
        }
    }
}
