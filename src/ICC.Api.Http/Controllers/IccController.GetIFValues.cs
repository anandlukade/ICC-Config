using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICC.Api.Http.Controllers
{
    public partial class IccController
   {        

        [Route("~/api/{country}/config/ifValues", Name = "config")]
        public HttpResponseMessage GetIFValues(string country, string env, string pipeline)
        {
            try
            {
                var values = Icc.GetPipelineValues(country, env, pipeline);
                return this.Request.CreateResponse(HttpStatusCode.Created, values);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }            
        }       
    }
}
