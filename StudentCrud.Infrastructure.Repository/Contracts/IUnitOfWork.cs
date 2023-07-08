using StudentCrud.Domain.Entities;

namespace StudentCrud.Infrastructure.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<StudentEntity, OutputEntity> Students { get; }
        Task CompleteAsync();
    }
}
