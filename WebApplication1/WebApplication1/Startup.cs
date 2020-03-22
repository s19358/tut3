using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.Services;

namespace WebApplication1
{  //setup the configuration of our server
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //container 
        {                                                       //herhangi bir controller constructorda bisey aliyorsa
                                                                //routing buraya gelcek
            services.AddTransient<IDbService, MockDbService>(); //idbservice tipinde bisey istenince direk mock uretilicek
            services.AddControllers();                           //json formatinda
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting(); //Route["api/students"]

            /* app.Run(async con =>
             {
                 con.Response.Headers.Add("secret", "12345aaaa"); //response a kendi headerimizi ekledik
             });                        //req res ayarlari adimlari gibi
                                         //sirasi onemli

             */
            app.UseAuthorization();    //immediately return 401
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
