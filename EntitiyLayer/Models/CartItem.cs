using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
