using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICartItemService
    {
        CartItem CartItemControl(int id,int cartId);
        void Insert (CartItem item);

        void Update (CartItem item);    

        List<CartItem> GetAllCartId (int CartId);

        CartItem GetCartItemByID (int CartId);

        void Delete (CartItem item);
        
    }
}
