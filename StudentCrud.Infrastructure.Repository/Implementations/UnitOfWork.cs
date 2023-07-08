using Serilog;
using StudentCrud.Domain.Entities;
using StudentCrud.Infrastructure.Persistence;
using StudentCrud.Infrastructure.Repository.Contracts;

namespace StudentCrud.Infrastructure.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ILogger _log;
        private readonly StudentContext _context;
        public IGenericRepository<StudentEntity, OutputEntity> Students { get; private set; }

        public UnitOfWork(ILogger log, StudentContext context, IGenericRepository<StudentEntity, OutputEntity> students)
        {
            _log = log;
            _context = context;
            Students = students;
        }

        public async Task CompleteAsync()
        {
            _log.Information("Task complete");
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _log.Information("Dispossing of the context");
            _context.Dispose();
        }
    }
}
