using StudentCrud.Domain.Entities;

namespace StudentCrud.Infrastructure.Repository.Contracts
{
    public interface IGenericRepository<TInputEntity, TOutputEntity>
        where TInputEntity : class where TOutputEntity : class
    {
        Task<IEnumerable<TOutputEntity>> GetAllAsync();
        Task<TOutputEntity?> GetByIdAsync(int id);
        Task<bool> AddAsync(TInputEntity model);
        Task<bool> Update(int id, TInputEntity model);
        Task<bool> DeleteAsync(int id);
    }
}
