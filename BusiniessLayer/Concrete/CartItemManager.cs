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
    public class CartItemManager:ICartItemService
    {
       private readonly ICartItemsDal _cartItemDal;

        public CartItemManager(ICartItemsDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public CartItem CartItemControl(int id,int cartId)
        {
            return _cartItemDal.GetByFilter(x=>x.ProductId==id && x.CartId==cartId);
        }

        public void Delete(CartItem item)
        {
            _cartItemDal.Delete(item);
        }

        public List<CartItem> GetAllCartId(int CartId)
        {
            return _cartItemDal.GetAllFilterInclude(x=>x.CartId==CartId , x=>x.Product);
        }

        public CartItem GetCartItemByID(int CartId)
        {
           return _cartItemDal.GetById(CartId);
        }

        public void Insert(CartItem item)
        {
           _cartItemDal.Insert(item);
        }

        public void Update(CartItem item)
        {
           _cartItemDal.Update(item);
        }
    }
}
