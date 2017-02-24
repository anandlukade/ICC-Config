using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
namespace ICC.Repository
{
    public partial class Icc
    {
        public Dictionary<string, string> GetPipelineValues(
            string country,
            string environment,
            string pipelineName)
        {
            if (string.IsNullOrEmpty(country) ||
                string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException(string.Empty, "Country not provided");
            }
            if (string.IsNullOrEmpty(pipelineName) ||
                string.IsNullOrWhiteSpace(pipelineName))
            {
                throw new ArgumentNullException(string.Empty, "Pipelinename not provided");
            }
            if (string.IsNullOrEmpty(environment) ||
                string.IsNullOrWhiteSpace(environment))
            {
                throw new ArgumentNullException(string.Empty, "Environment not provided");
            }
            Dictionary<string, string> pipelineValues = new Dictionary<string, string>();
            try
            {
                using (OracleConnection connection = new OracleConnection(
                    GetConnectionString(country, environment)))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        command.CommandText = "select PIPELINE_COMPONENT_PROPERTY.Name as Key, PIPELINE_COMPONENT_PROPERTY.Value as Value " +
                                             "from PIPELINE_COMPONENT_PROPERTY inner join PIPELINE_COMPONENT " +
                                             "on (PIPELINE_COMPONENT.id = PIPELINE_COMPONENT_ID) " +
                                             "inner join PIPELINE on (PIPELINE.id = PIPELINE_COMPONENT.PIPELINE_ID) " +
                                             "where lower(PIPELINE.NAME) = lower('" + pipelineName + "')";
                        command.Connection = connection;
                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            pipelineValues.Add(reader.GetString(0), reader.GetOracleClob(1).Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return pipelineValues;
        }
    }
}
