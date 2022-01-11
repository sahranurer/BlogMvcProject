using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITalentService
    {
        void Add(Talent talent);
        void Update(Talent talent);
        void Delete(Talent talent);
        List<Talent> GetTalents();
        Talent GetById(int id);
    }
}
