﻿using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.EntityFramework
{
    public class EFAboutDal : GenericRepositoriesDal<About>, IAboutDal
    {
        public EFAboutDal(AppDbContext context) : base(context)
        {
        }
    }
}
