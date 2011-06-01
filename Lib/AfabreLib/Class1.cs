using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AfabreLib.Properties;

namespace AfabreLib
{
    public static class AfabreHelper
    {
        public static SqlConnection CreateConnection()
        {
        	return new SqlConnection(Settings.Default.ConnectionString);
        }
    }
}
