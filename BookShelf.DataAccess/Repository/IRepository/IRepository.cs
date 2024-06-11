using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository.IRepository
{
        public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(String? includeProperties = null);
        T GET(Expression<Func<T, bool>> filter, String? includeProperties = null);
        void  Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
