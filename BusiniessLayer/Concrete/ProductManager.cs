using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;

        public ProductManager(IProductDal productDal, ICategoryDal categoryDal  )
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public void Delete(int id)
        {
            var value = _productDal.GetById(id);
            value.ProductStatus=false;
            _productDal.Update(value);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByCategory(string categoryName)
        {
            var category = _categoryDal.GetByFilter(c => c.CategoryName == categoryName);
            if (category == null)
                return new List<Product>(); 

            return _productDal.GetAllFilter(p => p.CategoryId == category.CategoryId);
        }

        public Product GetByIdProduct(int id)
        {
            return _productDal.GetByIdWithCategory(id);

        }

        public void Insert(Product product)
        {
           _productDal.Insert(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
