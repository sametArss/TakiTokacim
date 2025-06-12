using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Concrete.Repositories
{
    public class CategoryRepositories : ICategoryDal
    {
        private readonly AppDbContext _context;

        public CategoryRepositories(AppDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAllList()
        {
            return _context.Categories.ToList();
        }
    }
}
