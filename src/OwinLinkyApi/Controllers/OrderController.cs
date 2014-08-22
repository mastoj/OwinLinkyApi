using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Linky;
using OwinLinkyApi.Models;

namespace OwinLinkyApi.SelfHost.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [Route]
        [LinksFrom(typeof(IndexModel), "orders")]
        public HttpResponseMessage Get()
        {
            var orders = new List<Order>()
            {
                CreateOrder(1, "Tomas Jansson", 1000),
                CreateOrder(2, "Roy Fielding", 2000)
            };
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        [Route("details/{orderId}")]
        [LinksFrom(typeof(Order), "orderdetails")]
        public HttpResponseMessage Get(int orderId)
        {
            var orderDetail = CreateOrderDetail(orderId);
            return Request.CreateResponse(HttpStatusCode.OK, orderDetail);
        }

        [Route("{orderId}")]
        [HttpDelete]
        [LinksFrom(typeof(OrderDetail), "deleteorder")]
        [LinksFrom(typeof(Order), "deleteorder")]
        public HttpResponseMessage Delete(int orderId)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        private OrderDetail CreateOrderDetail(int orderId)
        {
            return new OrderDetail
            {
                OrderId = orderId,
                CustomerName = orderId == 1 ? "Tomas Jansson" : "Roy Fielding",
                OrderTotal = orderId == 1 ? 1000 : 2000,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        ItemPrice = 1000,
                        Quantity = orderId,
                        ProductName = "Magic api stuff",
                        ProductId = 1
                    }
                }
            };
        }

        private Order CreateOrder(int orderId, string name, int orderTotal)
        {
            return new Order
            {
                OrderId = orderId,
                CustomerName = name,
                OrderTotal = orderTotal
            };
        }
    }

}