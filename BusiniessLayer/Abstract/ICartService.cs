using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICartService
    {
        Cart UserActiveCart(System.Security.Claims.ClaimsPrincipal user);
        void Insert(Cart c);

        
    }
}
