using System.Linq.Expressions;

namespace Sosyopix_CaseStudy.Models.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        void Save();

        T Get(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetList();
    }


}
