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
using xuyang.CabBookingShop.Core.RepositoryInterfaces;
using xuyang.CabBookingShop.Core.ServiceInterfaces;
using xuyang.CabBookingShop.Infrastructure.Data;
using xuyang.CabBookingShop.Infrastructure.Repositories;
using xuyang.CabBookingShop.Infrastructure.Services;

namespace xuyang.CabBookingShop.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "xuyang.CabBookingShop.API", Version = "v1" });
            });

            // connect to database & DI
            services.AddDbContext<CabBookingShopDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("CabBookingShopDbConnection")));

            // Dependency Injection
            services.AddTransient<ICabTypeRepository, CabTypeRepository>();
            services.AddTransient<ICabTypeService, CabTypeService>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IHistoryRepository, HistoryRepository>();
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IBookingService, BookingService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "xuyang.CabBookingShop.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();
            });

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
