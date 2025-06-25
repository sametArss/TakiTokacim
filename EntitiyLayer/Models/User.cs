using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntitiyLayer.Models
{
    public class User : IdentityUser
    {
        [StringLength(100)]
        public string UserLName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool UserStatus { get; set; }

        public ICollection<UserAdress> UserAdresses { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
