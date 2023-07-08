using Microsoft.Extensions.DependencyInjection;

using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Domain.Services.Implementations;

namespace StudentCrud.Domain.Services.Configuration
{
    public static class DomainDI
    {
        public static void AddDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDomainService, DomainService>();
        }
    }
}
