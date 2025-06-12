using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(100)]
        public string CityName { get; set; }

        public ICollection<UserAdress> UserAdresses { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
