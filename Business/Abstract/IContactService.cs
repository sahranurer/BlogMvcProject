using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {


        List<Contact> GetContacts();
        void Add(Contact contact);
        void Delete(Contact contact);
        Contact GetbyId(int id);
        void Update(Contact contact);


    }
}
