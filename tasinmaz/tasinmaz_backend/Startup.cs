using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace tasinmaz_backend
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
            services.AddCors(options =>{
                options.AddPolicy(name :"MyCorsImplementationPolicy", 
                builder =>builder.WithOrigins("http://localhost:4200").AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod().WithMethods("PUT","POST","GET","DELETE").WithHeaders("Access-Control-Allow-Origin"));

            });
        //  services.AddIdentity<IdentityUser,IdentityRole>(
        //      options => {
        //          options.Password.RequireDigit=true;
        //          options.Password.RequireNonAlphanumeric=true; 
        //          options.Password.RequireUppercase=true;
        //          options.Password.RequireLowercase=true;


        //      }




        //  ).AddEntityFrameworkStores<DatabaseContext>();
          //services.AddDbContext<DatabaseContext>(options=>options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyCorsImplementationPolicy");
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
