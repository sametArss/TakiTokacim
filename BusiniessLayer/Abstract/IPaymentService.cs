using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IPaymentService
    {
        List<Payment> GetListByUser(System.Security.Claims.ClaimsPrincipal user);
        void Insert(Payment payment);
        void Delete(Payment payment);
        
        Payment GetById(int id);
    }
}
