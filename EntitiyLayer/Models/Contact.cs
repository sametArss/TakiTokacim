using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string UserNameLName { get; set;}
        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string UserMail { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public DateTime CreateDateMessage => DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
