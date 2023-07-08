using AutoMapper;
using Serilog;

using StudentCrud.Applcation.Services.Contracts;
using StudentCrud.Domain.Entities;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.DTOs;
using StudentCrud.Infrastructure.Repository.Contracts;

namespace StudentCrud.Applcation.Services.Implementations
{
    public class StudentApp : IStudentApp
    {
        private readonly ILogger _log;
        private readonly IMapper _mapper;
        private readonly IDomainService _domain;
        private readonly IUnitOfWork _repository;

        public StudentApp(ILogger log, IMapper mapper, IDomainService domain, IUnitOfWork repository)
        {
            _log = log;
            _mapper = mapper;
            _domain = domain;
            _repository = repository;
        }

        public async Task CreateStudentAsync(InputStudentDTO input)
        {
            _log.Information($"Application create student: {input}");
            var student = _mapper.Map<StudentEntity>(input);
            student.Age = _domain.CalculateAge(student.Birthday);
            if(await _repository.Students.AddAsync(student)) await _repository.CompleteAsync();
        }

        public async Task<OutputStudentDTO?> GetStudentByIdAsync(int id)
        {
            _log.Information($"Application get by id {id}");
            var data = await _repository.Students.GetByIdAsync(id);
            return _mapper.Map<OutputStudentDTO?>(data);
        }

        public async Task<IEnumerable<OutputStudentDTO>> GetAllStudentsAsync()
        {
            var data = await _repository.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<OutputStudentDTO>>(data);
        }

        public async Task<bool> UpdateStudentAsync(int id, InputStudentDTO input)
        {
            _log.Information($"Application update id: {id} student: {input}");
            var student = _mapper.Map<StudentEntity>(input);
            student.Age = _domain.CalculateAge(student.Birthday);
            if(await _repository.Students.Update(id, student)) await _repository.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            _log.Information($"Application delete student with id: {id}");
            if (await _repository.Students.DeleteAsync(id)) await _repository.CompleteAsync();
            return true;
        }
    }
}
