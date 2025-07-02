using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string FullName { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string Description { get; set; }

        [StringLength(11)]
        public string PhoneNum { get; set; }

        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        public int AdressId { get; set; }
        public virtual UserAdress UserAdress { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
