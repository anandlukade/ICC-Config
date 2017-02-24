using ICC.Data;
using System.Collections.Generic;

namespace ICC.IRepository
{
    public interface IIcc
    {
        Dictionary<string, string> GetPipelineValues(
            string country,
            string environment,
            string pipelineName);
        List<Pipeline> GetPipelines(
            string country,
            string environment);
    }
}
