using HelpDesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpDesk.Data.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        public DateTime? DateofBirth { get; set; }
        public UserType UserType { get; set; }
        public int? DepartmentId { get; set; }
    }
}
