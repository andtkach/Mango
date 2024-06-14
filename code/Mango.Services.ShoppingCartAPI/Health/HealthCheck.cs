using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mango.Services.CartAPI.Health
{
    public static class HealthCheck
    {
        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration["ConnectionStrings:DefaultConnection"], healthQuery: "select 1",
                    name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Cart", "Database" })
                .AddCheck<RemoteHealthCheck>("Remote endpoints Health Check", failureStatus: HealthStatus.Unhealthy)
                .AddCheck<MemoryHealthCheck>($"Cart Service Memory Check", failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "Cart Service" });


            //services.AddHealthChecksUI();
            services.AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                    opt.SetApiMaxActiveRequests(1); //api requests concurrency    
                    opt.AddHealthCheckEndpoint("Cart API", "/api/health"); //map health check api    

                })
                .AddInMemoryStorage();
        }
    }
}
