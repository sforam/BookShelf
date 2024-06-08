﻿using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<category>
    {   
        void update(category obj);
        
             
    }
}
