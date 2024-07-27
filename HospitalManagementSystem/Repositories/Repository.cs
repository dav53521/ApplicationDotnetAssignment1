using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HospitalSystemContext context;

        public Repository(HospitalSystemContext context)
        {
            this.context = context;
        }

        protected List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        protected List<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        protected T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        protected void Add(T entityToAdd)
        {
            context.Set<T>().Add(entityToAdd);
            context.SaveChanges();
        }

        protected void Remove(T entityToRemove)
        {
            context.Set<T>().Remove(entityToRemove);
            context.SaveChanges();
        }

        protected void Update(T entityToUpdate)
        {
            context.Set<T>().Update(entityToUpdate);
            context.SaveChanges();
        }

        protected void Save()
        {
            context.SaveChanges();
        }
    }
}
