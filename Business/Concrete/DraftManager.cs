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
    public class DraftManager : IDraftService

    {

        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void Add(Draft draft)
        {
            _draftDal.Insert(draft);
        }

        public void Delete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public Draft GetById(int id)
        {
            return _draftDal.Get(x => x.DraftID == id);
        }

        public List<Draft> GetDrafts()
        {
            return _draftDal.List();
        }

        public void Update(Draft draft)
        {
            _draftDal.Update(draft);
        }
    }
}
