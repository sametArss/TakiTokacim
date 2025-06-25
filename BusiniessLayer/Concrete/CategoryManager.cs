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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Delete(int id)
        {
            var value = _categoryDal.GetById(id);
            value.CategoryStatus = false; 
            _categoryDal.Update(value);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryDal.GetAll();
        }

        public Category GetByIdCategory(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Insert(Category category)
        {
           _categoryDal.Insert(category);   
        }

        public void Update(Category p)
        {
            _categoryDal.Update(p);
        }
    }
}
