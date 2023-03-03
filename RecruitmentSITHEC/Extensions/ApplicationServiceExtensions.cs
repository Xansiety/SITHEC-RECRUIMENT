using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.Helpers.Errors;
using RecruitmentSITHEC.Repository.Interfaces;
using RecruitmentSITHEC.Repository.Services;

namespace RecruitmentSITHEC.Extensions
{
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Dependency Injection Configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHumanService, HumanService>();
        }

        /// <summary>
        /// CORS Configuration
        /// </summary>
        /// <param name="services"></param> 
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// Global ModelState validation errors
        /// </summary>
        /// <param name="services"></param> 
        public static void AddValidationErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {

                    var errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                    .SelectMany(u => u.Value.Errors)
                                                    .Select(u => u.ErrorMessage).ToArray();

                    var errorResponse = new ValidationAPI()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }


        /// <summary>
        /// IP Rate Limiting Configuration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();

            //configuración
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = true;
                options.HttpStatusCode = 429; // Status code
                options.RealIpHeader = "X-Real-IP";  //Header read
                options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule {
                    Endpoint = "*", // Apply all endpoints
                    Period = "10s", // Time
                    Limit = 2 //Petition allowed per period
                }
            };
            });
        }


    }
}
