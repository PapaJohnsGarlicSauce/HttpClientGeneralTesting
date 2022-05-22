using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConfiguringHttpClientExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add named clients
            // Let's you configure custom policies, securities, delegates, etc. per client
            services.AddHttpClient("FirstBoredClient", client =>
            {
                client.BaseAddress = new Uri("https://www.boredapi.com/api/");
                // For funsies, let's make the clients accept different content types
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient("SecondBoredClient", client =>
            {
                // For the purpose of this example, these two addresses are the same
                client.BaseAddress = new Uri("https://www.boredapi.com/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
