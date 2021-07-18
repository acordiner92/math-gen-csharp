namespace Api.infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    public class ApiHealthCheck : IHealthCheck
    {
        private readonly MathGenDbContext dbContext;

        public ApiHealthCheck(MathGenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isOnline = await dbContext.Database.CanConnectAsync(cancellationToken);
            return isOnline ? HealthCheckResult.Healthy("System is up") : HealthCheckResult.Unhealthy("System is down");
        }
    }
}