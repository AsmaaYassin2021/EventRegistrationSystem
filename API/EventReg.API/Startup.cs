using EventReg.DB.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EventReg.API.Extensions;
using Serilog;

namespace EventReg.API
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
            var databaseConnectionString = Configuration["DatabaseConnectionString"];
            services.AddDbContext<EventDBContext>(options =>

               options.UseSqlServer(
                   databaseConnectionString
               ), ServiceLifetime.Scoped
           );

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();

            services.ConfigureSwaggerAPI();      
            services.ConfigureWrapper();
            services.ConfigureInvalidModel();
            services.ConfigureJWToken();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }

       
    }
}
