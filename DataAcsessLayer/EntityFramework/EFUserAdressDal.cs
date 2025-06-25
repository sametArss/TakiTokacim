using DataAcsessLayer.Abstract;
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
    public class EFUserAdressDal:GenericRepositoriesDal<UserAdress>,IUserAdressDal
    {
        public EFUserAdressDal(AppDbContext context) : base(context)
        {
            
        }
    }
}
