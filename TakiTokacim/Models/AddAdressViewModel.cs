using System.ComponentModel.DataAnnotations;

namespace TakiTokacim.Models
{
    public class AddAdressViewModel
    {
        [Required]
        [Display(Name = "Adres Başlığı")]
        public string AdressTitle { get; set; }

        [Required]
        [Display(Name = "Adres Açıklaması")]
        public string AdressDescription { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }
    }
} 