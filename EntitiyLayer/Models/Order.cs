using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Adı Soyadı zorunludur.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [StringLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır.")]
        public string PhoneNum { get; set; }

        public string Status { get; set; } = "Beklemede"; // varsayılan durum

        public string Description { get; set; }

        [Required(ErrorMessage = "Ödeme tipi seçimi zorunludur.")]
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        [Required(ErrorMessage = "Adres seçimi zorunludur.")]
        [ForeignKey("UserAdress")]
        public int UserAdressId { get; set; }

        public virtual UserAdress UserAdress { get; set; }

        [Required(ErrorMessage = "Kullanıcı atanmalıdır.")]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = "Sepet bilgisi zorunludur.")]
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue, ErrorMessage = "Toplam tutar sıfırdan küçük olamaz.")]
        public decimal TotalAmount { get; set; }

    }
}
