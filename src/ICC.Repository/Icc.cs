using ICC.IRepository;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace ICC.Repository
{
    public partial class Icc: IIcc
    {        
        
        private string GetConnectionString(
            string country,
            string enviroment)
        {
            using (OracleConnection connection = new OracleConnection(
                ConfigurationManager.ConnectionStrings[country + enviroment].ToString()))
            {
                using (OracleCommand command = new OracleCommand(
                    "select connection_string from connectionstring where connection_id='INTEGRATION'"))
                {
                    command.Connection = connection;
                    connection.Open();
                    object connectionObject = command.ExecuteScalar();
                    return connectionObject.ToString();
                }
            }
        }     
    }
}
