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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal  = aboutDal;
        }

        public About GetByAbout(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About about)
        {
            var value = _aboutDal.GetById(about.AboutId);
            _aboutDal.Update(value);
        }
    }
}
