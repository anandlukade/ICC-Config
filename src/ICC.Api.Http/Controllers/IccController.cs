using ICC.IRepository;
using ICC.Repository;
using System.Web.Http;

namespace ICC.Api.Http.Controllers
{
    [RoutePrefix("api/{country}/config")]
    public partial class IccController : ApiController
    {
        public IIcc Icc;
        public IccController(): 
            this (new Icc())
        {
        }
        public IccController(IIcc icc)
        {
            Icc = icc;
        }           
    }
}
