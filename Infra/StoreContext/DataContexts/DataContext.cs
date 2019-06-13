using Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Infra.StoreContext.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public DataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
    }
}
