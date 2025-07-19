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
    public class ContactManager:IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact contact)
        {
           _contactDal.Delete(contact);
        }

        public List<Contact> GetAllMessage()
        {
            return _contactDal.GetAll().OrderByDescending(x => x.ContactId).ToList();
        }

        public Contact GetByIdContact(int id)
        {
            return _contactDal.GetById(id);
        }

        public void Insert(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }


}
