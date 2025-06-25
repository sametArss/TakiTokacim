using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(200)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
