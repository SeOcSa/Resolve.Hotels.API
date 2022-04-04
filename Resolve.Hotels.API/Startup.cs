using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Resolve.Hotels.API.Services;
using Resolve.Hotels.DAL;
using Resolve.Hotels.DAL.Repositories.Concrete;
using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models;
using Resolve.Hotels.Models.AppSettings;
using Resolve.Hotels.Models.Enitities;

namespace Resolve.Hotels.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Resolve.Hotels APIs", Version = "v1"});
            });

            services.AddSingleton(new DbContext(Configuration["MongoDb:ConnectionString"]));
            services.AddSingleton(new MongoDocumentStore(new MongoStoreInfo
            {
                ConnectionString = Configuration["MongoDbStore:ConnectionString"],
                DatabaseName = Configuration["MongoDbStore:DatabaseName"],
                PartitionName = Configuration["MongoDbStore:PartitionName"]
            }));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelServices, HotelService>();
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200");
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "docs/api/{documentname}/swagger.json";
                });
                app.UseSwaggerUI( options =>
                {
                    options.SwaggerEndpoint("/docs/api/v1/swagger.json", "API Documentation");
                    options.RoutePrefix = "docs/api";
                });
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}