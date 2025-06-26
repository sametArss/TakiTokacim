using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class AdressManager : IAdressService
    {
        IUserAdressDal _userAdressDal;
        public AdressManager(IUserAdressDal userAdressDal)
        {
            _userAdressDal = userAdressDal;
        }

        public void Delete(UserAdress user)
        {
            var value = user;
            value.AdressStatus=false;
            _userAdressDal.Update(value);
        }

        public List<UserAdress> GetAdresses(System.Security.Claims.ClaimsPrincipal user)
        {
            var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return _userAdressDal.GetAllFilterInclude(x => x.UserId == userId && x.AdressStatus == true, x => x.City, x => x.District);
        }

        public UserAdress GetById(int id)
        {
          return _userAdressDal.GetById(id);
        }

        public void Insert(UserAdress user)
        {
            _userAdressDal.Insert(user);
        }

        public void Update(UserAdress user)
        {
            _userAdressDal.Update(user);
        }
    }

}
