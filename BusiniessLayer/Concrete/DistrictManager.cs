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
    public class DistrictManager:IDistrictService
    {
        private readonly IDistrictDal _districtDal;
        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public List<District> GetDistricts(int id)
        {
           return _districtDal.GetAllFilter(x=>x.CityId == id);
        }
    }
}
