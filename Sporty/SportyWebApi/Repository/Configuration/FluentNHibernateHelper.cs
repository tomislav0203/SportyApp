using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Repository.Mapping;

namespace Repository.Configuration
{
    public static class FluentNHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
			
             .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Server=tcp:tomislavsportserver.database.windows.net,1433;Initial Catalog=SportFinderDB;Persist Security Info=False;User ID=tomislavsipusic;Password=Stronghold000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                ).ShowSql())

             .Mappings(m => m.FluentMappings
             .AddFromAssemblyOf<UserMap>())
             .ExposeConfiguration(cfg => new SchemaExport(cfg)
             .Create(false, false))
             .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
