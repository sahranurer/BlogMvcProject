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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public void Add(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void Delete(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public Talent GetById(int id)
        {
            return _talentDal.Get(x => x.SkillID == id);
        }

        public List<Talent> GetTalents()
        {
            return _talentDal.List();
        }

        public void Update(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
