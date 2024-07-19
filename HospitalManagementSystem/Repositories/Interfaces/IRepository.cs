using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Find(Func<T, bool> predicate);
        public T? GetById(int id);
        public void Add(T entityToAdd);
        public void Remove(T entityToRemove);
        public void Update(T entityToUpdate);
        public void Save();
    }
}
