using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentCrud.Infrastructure.DataModels;
using StudentCrud.Infrastructure.Persistence;
using StudentCrud.Infrastructure.Repository.Contracts;

namespace StudentCrud.Infrastructure.Repository.Implementations
{
    public class GenericRepository<TInputEntity, TDataModel, TOutputEntity> : IGenericRepository<TInputEntity, TOutputEntity>
        where TInputEntity : class where TDataModel : DbIdentificator where TOutputEntity : class
    {
        protected readonly ILogger _log;
        protected readonly IMapper _mapper;
        protected StudentContext _contecxt;
        protected DbSet<TDataModel> _dbSet;

        public GenericRepository(ILogger log, IMapper mapper, StudentContext contecxt)
        {
            _log = log;
            _mapper = mapper;
            _contecxt = contecxt;
            _dbSet = _contecxt.Set<TDataModel>();
        }

        public virtual async Task<IEnumerable<TOutputEntity>> GetAllAsync()
        {
            _log.Information($"Getting all {typeof(TDataModel)}");
            var data = await _dbSet.ToListAsync();
            var entities = _mapper.Map<IEnumerable<TOutputEntity>>(data);
            return entities;
        }

        public virtual async Task<TOutputEntity?> GetByIdAsync(int id)
        {
            _log.Information($"Getting {typeof(TDataModel)} with id: {id}");
            var data = await _dbSet.FindAsync(id);
            var entity = _mapper.Map<TOutputEntity>(data);
            return entity;
        }

        public virtual async Task<bool> AddAsync(TInputEntity entity)
        {
            _log.Information($"Adding {typeof(TDataModel)}: {entity}");
            var data = _mapper.Map<TDataModel>(entity);
            await _dbSet.AddAsync(data);
            return true;
        }

        public virtual Task<bool> Update(int id, TInputEntity entity)
        {
            _log.Information($"Updating {typeof(TDataModel)} with id: {id} to {entity}");
            var data = _mapper.Map<TDataModel>(entity);
            data.Id = id;
            _dbSet.Update(data);
            return Task.FromResult(true);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            _log.Information($"Deleting {typeof(TDataModel)} with id: {id}");
            var data = await _dbSet.FindAsync(id);
            if (data != null) _dbSet.Remove(data);
            return true;
        }
    }
}
