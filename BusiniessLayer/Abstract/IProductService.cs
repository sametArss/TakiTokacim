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
        void Insert(Product product);
        void Update(Product product);

        void Delete(int id);
        Product GetByIdProduct(int id);
    }
}
