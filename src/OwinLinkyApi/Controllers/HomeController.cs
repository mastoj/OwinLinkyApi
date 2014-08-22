using System.Net;
using System.Net.Http;
using System.Web.Http;
using OwinLinkyApi.Models;

namespace OwinLinkyApi.SelfHost.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 
                new IndexModel
                {
                    WelcomeMessage = "Hello from API"
                });
        }
    }
}