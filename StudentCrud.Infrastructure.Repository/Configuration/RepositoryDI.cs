using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentCrud.Domain.Entities;
using StudentCrud.Infrastructure.DataModels;
using StudentCrud.Infrastructure.Persistence;
using StudentCrud.Infrastructure.Repository.Contracts;
using StudentCrud.Infrastructure.Repository.Implementations;

namespace StudentCrud.Infrastructure.Repository.Configuration
{
    public static class RepositoryDI
    {
        public static void AddRepositoryDependencies(this IServiceCollection services, string? connectionString)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<StudentContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IGenericRepository<StudentEntity, OutputEntity>, GenericRepository<StudentEntity, Student, OutputEntity>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void CreateDB(this IServiceProvider services)
        {
            var db = services.GetRequiredService<StudentContext>();
            db.Database.EnsureCreated();
        }
    }
}
