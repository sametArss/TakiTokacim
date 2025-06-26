using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IAdressService
    {
        void Insert(UserAdress user);
        List<UserAdress> GetAdresses(System.Security.Claims.ClaimsPrincipal user);

        void Update(UserAdress user);
        void Delete(UserAdress user);
        UserAdress GetById(int id);
    }
}
