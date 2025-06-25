using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IUserService
    {
        void Insert(User user);
        void Update(User user);
        
        void Delete(User user);
        
    }
}
