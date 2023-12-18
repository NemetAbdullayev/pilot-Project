﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T>where T:class
    {
        Task<T> Get(int id);
        Task<List<T>> Get();
        Task<T> Add(T t);
        Task<T> Update(T t);
        Task Delete(int id);
    }
}
