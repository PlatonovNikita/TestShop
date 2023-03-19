using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using IXORA.PlatonovNikita.TestShop.MappingProfile;
using IXORA.PlatonovNikita.TestShop.Model;
using IXORA.PlatonovNikita.TestShop.Repository;
using IXORA.PlatonovNikita.TestShop.Repository.Implementations;
using IXORA.PlatonovNikita.TestShop.Validators.ProductValidators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestShopContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddControllers();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ClientMappingProfile>();
                config.AddProfile<ProductMappingProfile>();
                config.AddProfile<OrderMappingProfile>();
            });
            services.AddMemoryCache();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Test Shop API", Version = "v1" });
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
                              IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Shop API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedData.Seed(services.GetRequiredService<TestShopContext>());
        }
    }
}
