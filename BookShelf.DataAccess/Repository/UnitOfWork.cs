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

        public IProductRepository Product { get; private set; }

        public ICompanyRepository Company { get; private set; }



        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
            Category = new CategoryRepository(dbContext);

            Product = new ProductRepository(dbContext);
            Company = new CompanyRepository(dbContext);

        }


        public void Save()
        {
          dbContext.SaveChanges();
        }
    }
}
