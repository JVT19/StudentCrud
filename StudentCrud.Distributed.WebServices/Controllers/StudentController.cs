using Microsoft.AspNetCore.Mvc;

using Serilog;
using StudentCrud.Applcation.Services.Contracts;
using StudentCrud.DTOs;

namespace StudentCrud.Distributed.WebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly Serilog.ILogger _log;
        private readonly IStudentApp _application;

        public StudentController(Serilog.ILogger log, IStudentApp application)
        {
            _log = log;
            _application = application;
        }

        [HttpPost(Name = "AddStudent")]
        public async Task<ActionResult> Add(InputStudentDTO student)
        {
            _log.Information($"Creating student: {student}");
            await _application.CreateStudentAsync(student);
            return Ok($"Student {student} created");
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<OutputStudentDTO>> GetStudent(int id)
        {
            _log.Information($"Getting student with id: {id}");
            var student = await _application.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet(Name = "GetStudents")]
        public async Task<ActionResult<IEnumerable<OutputStudentDTO>>> GetStudents()
        {
            _log.Information("Getting all students");
            return Ok(await _application.GetAllStudentsAsync());
        }

        [HttpPut("{id}", Name = "UpdateStudent")]
        public async Task<ActionResult> UpdateProduct(int id, InputStudentDTO student)
        {
            _log.Information($"Updating student with id {id} to {student}");
            if (await _application.UpdateStudentAsync(id, student)) return Ok(student);
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            _log.Information($"Deleting student with id: {id}");
            var student = await _application.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            await _application.DeleteStudentAsync(id);
            return Ok($"Deleted strudent {student.Name} {student.Surname}");
        }
    }
}
