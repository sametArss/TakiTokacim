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
    public class EFPaymentDal:GenericRepositoriesDal<Payment>,IPaymentDal
    {
        public EFPaymentDal(AppDbContext context) : base(context)
        {
            
        }
    }
}
