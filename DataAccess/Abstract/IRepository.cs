using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        List<T> List(Expression<Func<T,bool>> filter);
    }
}
