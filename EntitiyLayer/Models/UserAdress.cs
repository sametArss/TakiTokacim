using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntitiyLayer.Models
{
    public class UserAdress
    {
        [Key]
        public int AdressId { get; set; }

        [Required(ErrorMessage = "Adres başlığı zorunludur.")]
        [StringLength(150)]
        public string AdressTitle { get; set; }

        [StringLength(500)]
        public string AdressDescription { get; set; }

        public bool AdressStatus { get; set; }

        [Required(ErrorMessage = "UserId alanı zorunludur.")]
        public string UserId { get; set; }

        [BindNever, ValidateNever]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Şehir alanı zorunludur.")]
        public int CityId { get; set; }

        [BindNever, ValidateNever]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "İlçe alanı zorunludur.")]
        public int DistrictId { get; set; }

        [BindNever, ValidateNever]
        public virtual District District { get; set; }

        [BindNever, ValidateNever]
        public ICollection<Order> Orders { get; set; }
    }
}
