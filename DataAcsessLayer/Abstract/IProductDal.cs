﻿using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract
{
    public interface IProductDal : IGenericRepositoriesDal<Product>
    {
        Product GetByIdWithCategory(int id);
    }
}
  

