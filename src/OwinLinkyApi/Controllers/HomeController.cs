using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwinLinkyApi.SelfHost.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello from API");
        }
    }
}