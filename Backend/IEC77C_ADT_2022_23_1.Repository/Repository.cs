﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext Mycontext;
        private DbSet<TEntity> DbSet;

        IEnumerable<TEntity> IRepository<TEntity>.GetAll => GetAll();

        public Repository(DbContext context)
        {
            Mycontext = context;
            DbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll() 
        {
            return DbSet.AsEnumerable<TEntity>();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Mycontext.Entry(entity).State = EntityState.Modified;
            Mycontext.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            Mycontext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Mycontext.SaveChanges();
        }

        public T FindById(int ID)
        {
            return DbSet.Find(ID);
        }

        public void Update(T entity)
        {
           
        }

        TEntity IRepository<TEntity>.FindById(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
