using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleShop.Core;
using CandleShop.Core.DomainServices;
using CandleShop.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CandleShop.RestAPI
{
    public class Startup
    {
        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        */

        public IConfiguration Configuration { get; }
        
        private IHostingEnvironment _env { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            services.AddDbContext<CandleShopContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            
            services.AddScoped<ICandleRepository, CandleRepository>();
            services.AddScoped<ICandleService, CandleService>();
            
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            */
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<CandleShopContext>();

                ctx.Database.EnsureCreated();
                
                //DbInitializer.SeedDb(ctx);
            }
            
            app.UseHttpsRedirection();
            
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseMvc();
        }
    }
}