using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDraftService
    {
        void Add(Draft draft);
        void Update(Draft draft);
        void Delete(Draft draft);
        List<Draft> GetDrafts();
        Draft GetById(int id);
    }
}
