using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IContactService
    {
        void Insert(Contact contact);
        void Delete(Contact contact);
        List<Contact> GetAllMessage();
        Contact GetByIdContact(int id);
        void Update(Contact contact);
    }
}
