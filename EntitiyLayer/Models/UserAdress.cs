using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class UserAdress
    {
        [Key]
        public int AdressId { get; set; }
        [StringLength(150)]
        public string AdressTitle { get; set; }

        [StringLength(500)]
        public string AdressDescription { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
