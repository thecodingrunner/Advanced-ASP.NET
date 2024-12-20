using Advanced_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_ASP.NET.Controllers
{
        [Route("/api/teachers")]
        [ApiController]
        public class TeacherController : Controller
        {
            private readonly TeacherService _teacherService;
            public TeacherController(TeacherService teacherService)
            {
                _teacherService = teacherService;
            }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            if (teacher == null)
            {
                return BadRequest();
            }
            return Created( "Successfully added", teacher);
        }
    }
}
