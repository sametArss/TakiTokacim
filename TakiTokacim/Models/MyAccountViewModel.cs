using System.Collections.Generic;
using EntitiyLayer.Models;

namespace TakiTokacim.Models
{
    public class MyAccountViewModel
    {
        public string Email { get; set; }
        public string UserLName { get; set; }
        public List<UserAdress> Adresses { get; set; }
        public List<Payment> Payments { get; set; }
    }
} 