using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Insert(Order order)
        {
            _orderDal.Insert(order);
        }

        public List<Order> OrderList(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return _orderDal.GetAllFilterInclude(
    x => x.UserId == userId,
    x => x.UserAdress,
    x => x.Payment,
    x => x.Cart,
    x => x.Cart.CartItems
 );
        }
    }
}
