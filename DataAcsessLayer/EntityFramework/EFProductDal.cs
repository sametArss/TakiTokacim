using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.EntityFramework
{
    public class EFProductDal:GenericRepositoriesDal<Product>,IProductDal
    {
        private readonly AppDbContext _context;
        public EFProductDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Product GetByIdWithCategory(int id)
        {
            return _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
        }
    }
}
