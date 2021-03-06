using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetAdmin(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public List<Admin> GetAdmins()
        {
            return _adminDal.List();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
