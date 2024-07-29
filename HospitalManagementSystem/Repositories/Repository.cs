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

        //This constructor is storing the context as it'll be used to access the database
        public Repository(HospitalSystemContext context)
        {
            this.context = context;
        }

        protected List<T> GetAll()
        {
            //The context is being set so that entity framework will query the table that corresponds with T and all the data will be gotten as no filtering occurs 
            return context.Set<T>().ToList();
        }

        protected List<T> Find(Func<T, bool> predicate)
        {
            //
            return context.Set<T>().Where(predicate).ToList();
        }

        protected T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        protected void Add(T entityToAdd)
        {
            context.Set<T>().Add(entityToAdd);
            context.SaveChanges(); //Saving the new entity so that an Id can be generated for the entity and also so that the added entity can be gotten immediately
        }

        protected void Update(T entityToUpdate)
        {
            context.Set<T>().Update(entityToUpdate);
            context.SaveChanges(); //Saving the updated entity so that the changes are immediately reflected in the updated entity
        }

        //This function is just so that it is possible to save without doing any updates so it's possible to do things such as saving before exiting
        protected void Save()
        {
            context.SaveChanges();
        }
    }
}
