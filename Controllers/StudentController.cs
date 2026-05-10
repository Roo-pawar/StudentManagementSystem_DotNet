using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.GetAllStudents();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var result = await _service.AddStudent(student);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var result = await _service.UpdateStudent(student);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudent(id);

            return Ok(result);
        }
    }
}