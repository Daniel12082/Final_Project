using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UnitOfWork;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Domain.Interfaces;

namespace API.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)=>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader() //WithOrigins("https://localhost:4200")
                .AllowAnyMethod()   //WithMethods("GET", "POST", "PUT", "DELETE")
                .WithOrigins("http://127.0.0.1:5500"); //WithHeaders("accept", "content-type", "origin", "x-custom-header");
            });
        });
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Limit = 5,
                        Period = "10s"
                    },
                };
            });
        }
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}