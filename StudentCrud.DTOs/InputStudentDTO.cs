using System.Text;

namespace StudentCrud.DTOs
{
    public class InputStudentDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Surname: {Surname}");
            sb.AppendLine($"Birthday: {Birthday}");
            return sb.ToString();
        }
    }
}
