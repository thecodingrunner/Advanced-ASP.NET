using Advanced_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Advanced_ASP.NET.Controllers
{
    [Route("/api/spell")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class SpellController : Controller
    {
        private readonly SpellService _spellService;
        public SpellController(SpellService spellService)
        {
            _spellService = spellService;
        }

        // Creating an action Method
        [HttpGet]
        [EnableRateLimiting("fixed")]
        public IActionResult GetRandomSpell()
        {
            var spell = _spellService.GetRandomSpell();
            if (spell == null)
            {
                return NotFound();
            }
            return Ok(spell);
        }
    }
}
