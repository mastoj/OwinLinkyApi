using System.Net;
using System.Net.Http;
using System.Web.Http;
using Linky;
using OwinLinkyApi.Models;

namespace OwinLinkyApi.SelfHost.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductsController : ApiController
    {
        [Route("{productId}")]
        [LinksFrom(typeof(OrderLine), "product")]
        public HttpResponseMessage Get(int productId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Product()
            {
                ItemPrice = 1000,
                ProductId = productId,
                ProductName = "Magic api stuff",
                InStock = 100
            });
        }

        [HttpPost]
        [Route("{productId}")]
        [LinksFrom(typeof(Product), "ordermoreproducts")]
        public HttpResponseMessage OrderMore(int productId)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }

}