using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from custom Middleware");
            await next(context);
            await context.Response.WriteAsync("Hello from custom Middleware after Next() \n");

        }
    }
}
