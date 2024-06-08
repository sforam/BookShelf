using BookWise.DataAccess.Data;
using BookWise.DataAccess.Repository.IRepository;
using BookWise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookWise.DataAccess.Repository
{
	public class CategoryRepository : Repository<category>,ICategoryRepository
	{
		private ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
			this.dbContext = dbContext;

		}



		public void Save()
		{
			dbContext.SaveChanges();
		}

		public void Update(category obj)
		{
			dbContext.Categories.Update(obj);
		}
	}
}
