using Advanced_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Advanced_ASP.NET.Controllers
{
        [Route("/api/teachers")]
        [ApiController]
        public class TeacherController : Controller
        {
            private readonly TeacherService _teacherService;
            private readonly IMemoryCache _memoryCache;
            private const string TeacherCacheKey = "TeacherList";

        public TeacherController(TeacherService teacherService, IMemoryCache memoryCache)
            {
                _teacherService = teacherService;
                _memoryCache = memoryCache;
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

        [HttpDelete("{id}")]
        public IActionResult AddTeacher(int id)
        {
            Teacher deletedTeacher = _teacherService.DeleteTeacher(id);
            if (deletedTeacher == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            List<Teacher> teachers;
           
            if (!_memoryCache.TryGetValue(TeacherCacheKey, out teachers))
            {
                teachers = _teacherService.GetAllTeachers();

                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                _memoryCache.Set(TeacherCacheKey, teachers, cacheEntryOptions);
            }
            return Ok(teachers);    
        }
    }
}
