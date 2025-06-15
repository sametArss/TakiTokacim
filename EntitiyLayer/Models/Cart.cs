using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public bool CartStatus { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
