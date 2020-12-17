using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpDesk.Data.Dto
{
    public class TicketDto
    {
        public int? Id { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FromUserId { get; set; }
    }

}
