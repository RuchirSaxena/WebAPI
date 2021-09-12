using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello form Run Mehod");
            //});

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello form Use Method1 \n");
                await next();
                await context.Response.WriteAsync("Hello form Use Method 2 \n");
            });
            // Custom code execution based on the Route
           // app.Map("/ruchir", CustomCode);
            app.UseMiddleware<CustomMiddleware>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello form Use Method 3 \n");
                await next();
                await context.Response.WriteAsync("Hello form Use Method 4 \n");
            });

           

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello form Run Mehod2 \n");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endppoints =>
            {
                endppoints.MapControllers();
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello form custom Map Mehod \n");
            });
        }
    }
}
