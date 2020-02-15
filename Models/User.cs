using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public bool CustomerUser { get; set; }
        [Required]
        public bool InternalUser { get; set; }
        [Required]
        public bool SupplierUser { get; set; }
        [Required]
        public string IdentityCode { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual IEnumerable<Ticket> Tickets { get; set; }
    }
}
