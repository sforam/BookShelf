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
    public class CompanyRepository : Repository<company>, ICompanyRepository
    {
        private ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }


        public void update(company obj)
        {
            dbContext.Companies.Update(obj);
        }
    }
}
