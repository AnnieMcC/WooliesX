using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WooliesX.API.Infrastructure;
using WooliesX.Core.Filters;
using WooliesX.Core.Interfaces;
using WooliesX.Core.Models;
using WooliesX.Data.Services;

namespace WooliesX.API
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
            services.AddDbContext<AppDbContext>(options =>
                     options.UseInMemoryDatabase("WooliesXDb"));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopperHistoryService, ShopperHistoryService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc(options =>
            {
                options.Filters.Add<JsonExceptionFilter>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowWooliesX", policy =>
                        policy.AllowAnyOrigin());
            });

            services.AddAutoMapper(options =>
                    options.AddProfile<MappingProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
           
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WooliesXAPI V1");
            });

            app.UseCors("AllowWooliesX");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
