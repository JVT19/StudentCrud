using StudentCrud.DTOs;

namespace StudentCrud.Applcation.Services.Contracts
{
    public interface IStudentApp
    {
        Task CreateStudentAsync(InputStudentDTO input);
        Task<OutputStudentDTO?> GetStudentByIdAsync(int id);
        Task<IEnumerable<OutputStudentDTO>> GetAllStudentsAsync();
        Task<bool> UpdateStudentAsync(int id, InputStudentDTO input);
        Task<bool> DeleteStudentAsync(int id);
    }
}
