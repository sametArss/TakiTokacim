using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        [StringLength(100)]
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }
        public ICollection<UserAdress> UserAdresses { get; set; }
    }
}
