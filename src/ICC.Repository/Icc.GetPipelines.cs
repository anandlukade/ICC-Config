using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using ICC.Data;
using System.Data;

namespace ICC.Repository
{
    public partial class Icc
    {
        public List<Pipeline> GetPipelines(
            string country,            
            string environment)
        {
            if (string.IsNullOrEmpty(country) ||
                string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException(string.Empty, "Country not provided");
            }            
            if (string.IsNullOrEmpty(environment) ||
                string.IsNullOrWhiteSpace(environment))
            {
                throw new ArgumentNullException(string.Empty, "Environment not provided");
            }
            List<Pipeline> pipelines = new List<Pipeline>();
            try
            {
                using (OracleConnection connection = new OracleConnection(
                    GetConnectionString(country, environment)))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        command.CommandText = "select Id,Name,Key,Processing_queue as Queue,status from pipeline";
                        command.Connection = connection;
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach(DataRow dr in dataTable.Rows)
                        {
                            Pipeline pipeline = new Pipeline();
                            pipeline.Id = dr["Id"].ToString();
                            pipeline.Name = dr["Name"].ToString();
                            pipeline.Key = dr["Key"].ToString();
                            pipeline.Queue = dr["Queue"].ToString();
                            pipeline.Status = dr["status"].ToString();
                            pipelines.Add(pipeline);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return pipelines;
        }
    }
}
