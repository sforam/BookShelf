﻿using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<company>
    {
        void update(company obj);


    }
   
}
