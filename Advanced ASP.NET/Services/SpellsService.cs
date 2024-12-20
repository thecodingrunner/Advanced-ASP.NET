using Advanced_ASP.NET.Models;

namespace Advanced_ASP.NET.Services
{
    public class SpellsService
    {
        private readonly SpellsModel _spellsModel;
        public SpellsService(SpellsModel spellsModel)
        {
            _spellsModel = spellsModel;
        }

        public List<Spell>? GetAllSpells()
        {
            return _spellsModel.FetchSpells();
        }
        
       
    
    }
}
