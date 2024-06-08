﻿using BookWise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWise.DataAccess.Repository.IRepository
{
	 public interface ICategoryRepository:IRepository<category>
	{
		void Update(category obj);
		void Save();


	}
}
