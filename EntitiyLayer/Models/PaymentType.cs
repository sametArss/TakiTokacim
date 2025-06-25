using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class PaymentType
    {
        [Key]
        public int TypeId { get; set; }
        [StringLength(150)]
        public string TypeName { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
