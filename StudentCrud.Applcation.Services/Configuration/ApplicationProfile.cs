using AutoMapper;
using StudentCrud.Domain.Entities;
using StudentCrud.DTOs;

namespace StudentCrud.Applcation.Services.Configuration
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<InputStudentDTO, StudentEntity>();
            CreateMap<StudentEntity, InputStudentDTO>();

            CreateMap<OutputEntity, OutputStudentDTO>();
            CreateMap<OutputStudentDTO, OutputEntity>();
        }
    }
}
