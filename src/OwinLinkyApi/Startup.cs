using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace OwinLinkyApi
{
    using AppFunc = Func<
        IDictionary<string, object>, // Environment
        Task>; // Done

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            Linky.LinkyConfiguration.Configure(configuration);
            app.UseWebApi(configuration);

            app.Use(new Func<AppFunc, AppFunc>(next => async env =>
            {
                var responseStream = env["owin.ResponseBody"] as Stream;
                var message = Encoding.UTF8.GetBytes("Hello world");
                await responseStream.WriteAsync(message, 0, message.Length);
                await next(env);
                await responseStream.WriteAsync(message, 0, message.Length);
            }));
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from number 2");
                await context.Response.WriteAsync("More stuff from number 2");
            });
        }
    }
}