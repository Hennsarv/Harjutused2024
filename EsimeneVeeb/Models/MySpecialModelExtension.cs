using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace EsimeneVeeb.Models
{
    public class MySpecialModelExtension
    {
    }




public partial class NorthwindEntities : DbContext
    {

        public NorthwindEntities(string x) 
            :base(ModifyConnectionString())  
        { }

        private static string ModifyConnectionString()
        {
            string entityConnectionStringFromConfig = ConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString;

            var entityBuilder = new EntityConnectionStringBuilder(entityConnectionStringFromConfig);
            var builder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);
            builder.UserID = "Student";
            builder.Password = "Pa$$w0rd";

            entityBuilder.ProviderConnectionString = builder.ConnectionString;
            return entityBuilder.ConnectionString;
        }
    }


}