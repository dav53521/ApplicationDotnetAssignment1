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

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Add(T entityToAdd)
        {
            context.Set<T>().Add(entityToAdd);
        }

        public void Remove(T entityToRemove)
        {
            context.Set<T>().Remove(entityToRemove);
        }

        public void Update(T entityToUpdate)
        {
            context.Set<T>().Update(entityToUpdate);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
