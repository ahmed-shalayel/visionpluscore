using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpDesk.Data.Model
{
    public class Department : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }

        public List<User> Users { get; set; }
        public List<Ticket> Tickets { get; set; }
        
    }
}
