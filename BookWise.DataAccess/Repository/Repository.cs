﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookWise.DataAccess.Data;
using BookWise.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookWise.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{

		private readonly ApplicationDbContext dbContext;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
			this.dbSet = dbContext.Set<T>();
			//dbContext.Categories == dbSet
			
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query=query.Where(filter);
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{

			IQueryable<T> query = dbSet;
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
