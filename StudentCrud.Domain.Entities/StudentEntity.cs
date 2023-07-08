using System.Text;

namespace StudentCrud.Domain.Entities
{
    public class StudentEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Surname: {Surname}");
            sb.AppendLine($"Birthday: {Birthday}");
            sb.AppendLine($"Age: {Age}");
            return sb.ToString();
        }
    }
}
