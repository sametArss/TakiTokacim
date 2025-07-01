using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [StringLength(100)]
        public string PaymentName { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int TypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        [StringLength(20)]
        public string CardNumber { get; set; }
        [StringLength(3)]
        public string CardCvv { get; set; }
        [StringLength(5)]
        public string CardDate { get; set; }

        public bool PaymentStatus { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
