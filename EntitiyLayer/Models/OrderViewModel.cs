using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Adı Soyadı zorunludur.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [StringLength(11)]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "Adres seçimi zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen bir adres seçiniz.")]
        public int AdressId { get; set; }

        [Required(ErrorMessage = "Ödeme kartı seçimi zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen bir kart seçiniz.")]
        public int PaymentId { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }
    }
} 