using System.Data;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace com.terriblecode.dal
{
    public static class SessionFactoryFactory
    {
        public static readonly ISessionFactory Instance = Build();

        public static ISessionFactory Build()
        {
            var configuration = new Configuration();
            configuration.SessionFactoryName("TerribleCode");

            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Dialect<MsSql2012Dialect>();
                db.Driver<Sql2008ClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = "Data Source=(local);Initial Catalog=EmployeeManagement;User ID=employeemanagementuser;Password=qazxsw21;Asynchronous Processing=True";
                db.Timeout = 10;
                db.BatchSize = 20;
            });

            var modelMapper = ConstructModelMapper();

            configuration.AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());

            return configuration.BuildSessionFactory();
        }

        private static ModelMapper ConstructModelMapper()
        {
            var modelMapper = new ModelMapper();

            modelMapper.AddMapping<EmployeeMap>();

            return modelMapper;
        }
    }
}