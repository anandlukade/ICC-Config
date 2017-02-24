using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ICC.Api.Http.Controllers
{
    public partial class IccController
   {        

        [Route("~/api/{country}/config-pipelines/", Name = "pipelines")]
        public HttpResponseMessage GetPipelines(string country, string env)
        {
            try
            {
                var values = Icc.GetPipelines(country, env);
                return this.Request.CreateResponse(HttpStatusCode.OK, values);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }            
        }       
    }
}
