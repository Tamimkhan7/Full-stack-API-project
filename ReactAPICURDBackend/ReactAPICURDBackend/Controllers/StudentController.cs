using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAPICURDBackend.Data;
using ReactAPICURDBackend.Models;

namespace ReactAPICURDBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Students
        [HttpGet("GetStudent")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.students.ToListAsync();
            return Ok(students);
        }

        // Add New Student
        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> AddStudent([FromBody] Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        // Update Student
        [HttpPatch("UpdateStudent/{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student)
        {
            var existingStudent = await _context.students.FindAsync(id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.stname = student.stname;
            existingStudent.course = student.course;

            await _context.SaveChangesAsync();
            return Ok(existingStudent);
        }

        // Delete Student
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
