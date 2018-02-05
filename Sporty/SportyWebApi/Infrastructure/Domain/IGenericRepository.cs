
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.Domain
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        T Single(Expression<Func<T, bool>> predicates);
        IEnumerable<T> All(Expression<Func<T, bool>> predicates);
    }
}

