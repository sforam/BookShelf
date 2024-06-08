using BookShelf.DataAccess.Data;
using BookShelf.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext dbContext;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
            Category = new CategoryRepository(dbContext);

        }

       
        public void Save()
        {
          dbContext.SaveChanges();
        }
    }
}
