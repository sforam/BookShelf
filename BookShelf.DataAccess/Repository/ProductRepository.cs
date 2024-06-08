using BookShelf.DataAccess.Data;
using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }
     
        public void update(Product obj)
        {
            dbContext.Products.Update(obj);
        }
    }
}
