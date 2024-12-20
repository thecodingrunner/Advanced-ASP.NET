using Microsoft.AspNetCore.Mvc;
using Advanced_ASP.NET.Services;

namespace Advanced_ASP.NET.Controllers
{
    [Route("/api/spells")]
    [ApiController]
    public class SpellsController : Controller
    {
        private readonly SpellsService _spellsService;
        public SpellsController(SpellsService spellsService)
        {
            _spellsService = spellsService;
        }

        // Creating an action Method
        [HttpGet]
        public IActionResult GetAllSpells()
        {
            var spells = _spellsService.GetAllSpells();
            if (spells == null)
            {
                return NotFound();
            }
            return Ok(spells);
        }
    }
}
