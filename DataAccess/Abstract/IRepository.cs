using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
    }
}
