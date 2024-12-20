using Advanced_ASP.NET.Models;

namespace Advanced_ASP.NET.Services
{
    public class SpellService
    {
        private readonly SpellModel _spellModel;
        public SpellService(SpellModel spellModel)
        {
            _spellModel = spellModel;
        }

        public Spell? GetRandomSpell()
        {
            return _spellModel.FetchRandomSpell();
        }
        
       
    
    }
}
