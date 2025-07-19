using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class About
    {
        [Key]
        public int AboutId  { get; set; }
        public string AboutMessage { get; set; }
        public DateTime CreateDateAbout => DateTime.Now;
    }
}
