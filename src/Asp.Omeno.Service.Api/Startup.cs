using Asp.Omeno.Service.Api.Extensions;
using Asp.Omeno.Service.Api.Filters;
using Asp.Omeno.Service.Application.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Asp.Omeno.Service.Api
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
            services.RegisterServices(Configuration);
            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            }).UseServices();
            services.AddControllers();
            services.AddSignalR();
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.AddServices(Configuration);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("SiteCorsPolicy");
                endpoints.MapHub<ProductHub>("/product");
            });
        }
    }
}
