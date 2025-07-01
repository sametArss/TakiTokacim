using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICartService
    {
        List<Cart> GetListByUser(System.Security.Claims.ClaimsPrincipal user);
    }
}
