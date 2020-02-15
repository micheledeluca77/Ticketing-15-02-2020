using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Ticket Request")]
        public string Request { get; set; }
        [Required]
        [Display(Name = "Ticket Response")]
        public string Response { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Request Date")]
        public DateTime RequestTime { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Response Date")]
        public DateTime? ResponseTime { get; set; }
        [Range(1, 3)]
        public int State { get; set; } // 1. Not Managed, 2. In Progress, 3. Done

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
