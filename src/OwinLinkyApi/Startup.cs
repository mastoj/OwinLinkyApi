using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
            app.Use(new Func<AppFunc, AppFunc>(next => async env =>
            {
                var responseStream = env["owin.ResponseBody"] as Stream;
                var message = Encoding.UTF8.GetBytes("Hello world");
                await responseStream.WriteAsync(message, 0, message.Length);
                await next(env);
                await responseStream.WriteAsync(message, 0, message.Length);
            }));
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from number 2");
                await next.Invoke();
                await context.Response.WriteAsync("More stuff from number 2");
            });
        }
    }
}