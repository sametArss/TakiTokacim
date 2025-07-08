using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class CartManager : ICartService
    {
       private readonly ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Insert(Cart c)
        {
            _cartDal.Insert(c);
        }

        public void Update(Cart c)
        {
            var value=_cartDal.GetById(c.CartId);
            value.CartStatus = false;
            _cartDal.Update(value);
        }

        public Cart UserActiveCart(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return _cartDal.GetAllFilter(x => x.UserId == userId && x.CartStatus == true).FirstOrDefault();
        }


    }
}
