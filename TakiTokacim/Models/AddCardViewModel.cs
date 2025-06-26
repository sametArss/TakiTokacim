using System.ComponentModel.DataAnnotations;

namespace TakiTokacim.Models
{
    public class AddCardViewModel
    {
        [Required]
        [Display(Name = "Kart Adı")]
        public string PaymentName { get; set; }

        [Required]
        [Display(Name = "Kart Numarası")]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Son Kullanma Tarihi (AA/YY)")]
        public string CardDate { get; set; }

        [Required]
        [Display(Name = "CVV")]
        [StringLength(4, MinimumLength = 3)]
        public string CardCvv { get; set; }
    }
} 