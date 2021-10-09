using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;

namespace Antra.HotelManagement.Data.Repository
{
    class HotelManagementContext
    {
        public IDbConnection GetConnection()
        {
            string con = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("HotelManagement");
            return new SqlConnection(con);
        }
    }
}
