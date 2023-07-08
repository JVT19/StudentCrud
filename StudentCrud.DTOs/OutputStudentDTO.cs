using System.Text;

namespace StudentCrud.DTOs
{
    public class OutputStudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int? Age { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Surname: {Surname}");
            sb.AppendLine($"Birthday: {Birthday}");
            sb.AppendLine($"Age: {Age}");
            sb.AppendLine($"CreatedAt: {CreatedAt}");
            return sb.ToString();
        }
    }
}
