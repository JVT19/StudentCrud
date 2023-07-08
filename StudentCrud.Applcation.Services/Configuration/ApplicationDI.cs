using Microsoft.Extensions.DependencyInjection;

using StudentCrud.Applcation.Services.Contracts;
using StudentCrud.Applcation.Services.Implementations;
using StudentCrud.Domain.Services.Configuration;
using StudentCrud.Infrastructure.Repository.Configuration;

namespace StudentCrud.Applcation.Services.Configuration
{
    public static class ApplicationDI
    {
        public static void AddApplicationDependencies(this IServiceCollection services, string? connectionString)
        {
            services.AddDomainDependencies();
            services.AddRepositoryDependencies(connectionString);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IStudentApp, StudentApp>();
        }

        public static void CreateDBApplication(this IServiceProvider services)
        {
            services.CreateDB();
        }
    }
}
