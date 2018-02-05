using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Domain;
using NHibernate;
using NHibernate.Criterion;
using Repository.Configuration;

namespace Repository.Repos
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private UnitOfWork _unitOfWork;
        protected ISession Session { get { return _unitOfWork.Session; } }

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public virtual void Add(T entity)
        {
            Session.Save(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public T Single(Expression<Func<T, bool>> predicates)
        {
            // Get object from nHibernate session object
            var retObj = Session
                .Query<T>()
                .Where(predicates).SingleOrDefault();

            return retObj;
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> predicates)
        {
            // Get list of objects from nHibernate session object
            var retObj = Session
                .Query<T>()
                .Where(predicates);

            return retObj;
        }
    }
}
