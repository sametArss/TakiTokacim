using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface  IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetByCategory(string categoryName);

        Product GetByIdProduct(int id);
    }
}
