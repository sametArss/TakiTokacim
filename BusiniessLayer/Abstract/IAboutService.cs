using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IAboutService
    {
        About GetByAbout(int id);
        void Update(About about);   
    }
}
