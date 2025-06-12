using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(250)]
        public string ProductName { get; set; }
        [StringLength(500)]
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public short ProductStock { get; set; }

        public bool ProductStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }



    }
}
