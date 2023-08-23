using Microsoft.EntityFrameworkCore;
using Sosyopix_CaseStudy.Models.Repository.Abstract;
using Sosyopix_CaseStudy.Models.Utility;
using System.Linq.Expressions;

namespace Sosyopix_CaseStudy.Models.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> sorgu = dbSet;
            sorgu = sorgu.Where(filter);

            return sorgu.FirstOrDefault();

        }

        public IEnumerable<T> GetList()
        {
           IEnumerable<T> sorgu = dbSet;

            return sorgu.ToList();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
