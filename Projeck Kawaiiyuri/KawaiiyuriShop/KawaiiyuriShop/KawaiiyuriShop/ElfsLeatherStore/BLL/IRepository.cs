﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElfsLeatherStore.BLL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}