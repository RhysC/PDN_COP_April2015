using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Autofac;

using Nancy.Bootstrappers.Autofac;

namespace SimplerWay
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override ILifetimeScope GetApplicationContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Register(context => new SqlConnection(ConfigurationManager.ConnectionStrings["simpler"].ConnectionString))
                .As<IDbConnection>();

            return containerBuilder.Build();
        }
    }
}