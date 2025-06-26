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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(System.Security.Claims.ClaimsPrincipal user)
        {
            return user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }

        public void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }


    }
}
