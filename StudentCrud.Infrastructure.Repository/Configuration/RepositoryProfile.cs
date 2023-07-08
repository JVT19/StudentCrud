using AutoMapper;

using StudentCrud.Domain.Entities;
using StudentCrud.Infrastructure.DataModels;

namespace StudentCrud.Infrastructure.Repository.Configuration
{
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            CreateMap<StudentEntity, Student>();
            CreateMap<Student, StudentEntity>();

            CreateMap<Student, OutputEntity>();
            CreateMap<OutputEntity, Student>();
        }
    }
}
