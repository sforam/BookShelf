using BookShelf.DataAccess.Data;
using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {
        private ApplicationDbContext dbContext;

        public OrderHeaderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }
       

        public void update(OrderHeader obj)
        {
            dbContext.OrderHeaders.Update(obj);
        }
    }
}
