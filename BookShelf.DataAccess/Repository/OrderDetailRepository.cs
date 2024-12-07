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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext dbContext;

        public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }
       

        public void update(OrderDetail obj)
        {
            dbContext.OrderDetails.Update(obj);
        }
    }
}
