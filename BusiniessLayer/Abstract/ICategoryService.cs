using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        void Insert(Category category);
        Category GetByIdCategory(int id);
        void Delete(int id);
        void Update(Category p);
    }
}
