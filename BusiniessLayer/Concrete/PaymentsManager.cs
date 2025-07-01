using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class PaymentsManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        public PaymentsManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public void Delete(Payment payment)
        {
            var values = payment;
            payment.PaymentStatus=false;
            _paymentDal.Update(values);
        }

        public Payment GetById(int id)
        {
           return _paymentDal.GetById(id);
           
        }

        public List<Payment> GetListByUser(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return _paymentDal.GetAllFilter(x=>x.UserId == userId && x.PaymentStatus==true);
        }

        public void Insert(Payment payment)
        {
            payment.PaymentStatus=true;
           _paymentDal.Insert(payment);
        }
    }
}
