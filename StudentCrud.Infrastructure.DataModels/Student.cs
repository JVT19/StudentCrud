namespace StudentCrud.Infrastructure.DataModels
{
    public class Student : DbIdentificator
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
    }
}
