using CCSA_Web.Db.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace CCSA_Web.DB
{
    public class SessionFactory
    {
        public SessionFactory(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SalesManagement");
            session = CreateSessionFactory(connectionString).OpenSession();
        }
        
        public  ISession session;
        
        private static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString
                (connectionString))
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssembly(typeof(UserMap).Assembly);
            })
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
        }
    }
}
