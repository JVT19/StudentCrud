using StudentCrud.Domain.Services.Contracts;

namespace StudentCrud.Domain.Services.Implementations
{
    public class DomainService : IDomainService
    {
        public int CalculateAge(DateTime bday) => (DateTime.Now.Year - bday.Year);
    }
}
