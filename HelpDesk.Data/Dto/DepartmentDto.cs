using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpDesk.Data.Dto
{
    public class DepartmentDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string AdminId { get; set; }
    }
}
