using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace DAL
{
    public static class Conexao
    {
        public static ISessionFactory CreateSessionFactory<T>()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.Is(connectionString)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            SchemaExport schema = new SchemaExport(config);
            schema.Drop(false, false);
            schema.Create(false, false);
        }
    }
}
