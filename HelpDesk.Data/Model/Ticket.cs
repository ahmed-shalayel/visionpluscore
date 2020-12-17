using HelpDesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpDesk.Data.Model
{
    public class Ticket : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime EstimatedStartAt { get; set; }
        [Required]
        public DateTime EstimatedEndAt { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public string RejecteReason { get; set; }

        public string FromUserId { get; set; }

        public User FromUser { get; set; }

        public string Image { get; set; }

        public List<TicketFiles> TicketFiles { get; set; }

        public List<TicketTimeLine> TicketTimeLines { get; set; }

        
    }
}
