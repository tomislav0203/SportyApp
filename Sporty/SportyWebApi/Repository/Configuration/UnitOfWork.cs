using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Repository.Mapping;

namespace Repository.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = Fluently.Configure()

            .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Server=tcp:tomislavsportserver.database.windows.net,1433;Initial Catalog=SportFinderDB;Persist Security Info=False;User ID=tomislavsipusic;Password=Stronghold000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
               ).ShowSql())

            .Mappings(m => m.FluentMappings
            .AddFromAssemblyOf<UserMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(false, false))
            .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
