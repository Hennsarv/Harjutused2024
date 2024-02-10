using Microsoft.AspNet.Identity;
using Microsoft.Win32;
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

            string regKeyPath = @"HKEY_LOCAL_MACHINE\Software\HennTest";
            string serverName = (string)Registry.GetValue(regKeyPath, "ServerName", null);
            string user = (string)Registry.GetValue(regKeyPath, "DBUser", null);
            string password = (string)Registry.GetValue(regKeyPath, "Password", null);



            var entityBuilder = new EntityConnectionStringBuilder(entityConnectionStringFromConfig);
            var builder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);
            builder.UserID = user; 
            builder.Password = password; 

            entityBuilder.ProviderConnectionString = builder.ConnectionString;
            return entityBuilder.ConnectionString;
        }
    }


}