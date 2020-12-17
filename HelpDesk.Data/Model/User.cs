using HelpDesk.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpDesk.Data.Model
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string FullName { get { return FirstName + "" + LastName; }  }


        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }

        public DateTime? DateofBirth { get; set; }
        public string UserImage { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public UserType UserType { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public List<Ticket> Tickets { get; set; }
    }
}
