using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookShelf.DataAccess.Data;
using BookShelf.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BookShelf.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext dbContext;

        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();

            dbContext.Products.Include(u => u.category).Include(u => u.CategoryId);
            //dbContext.Categories == dbSet

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);

        }

        public T Get(Expression<Func<T, bool>> filter, String? includeProperties = null,bool tracked=false)
        {
            IQueryable<T> query;

            if(tracked){
                query = dbSet;
            }
            else{
                 query = dbSet.AsNoTracking();
            }
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }


            return query.FirstOrDefault();
        }

        //Category,CoverType

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, String? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {

                query = query.Where(filter);

            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }


            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
