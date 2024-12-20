using System.Text.Json;

namespace Advanced_ASP.NET.Models
{
    public class SpellsModel
    {
        public List<Spell>? FetchSpells()
        {
            var json = File.ReadAllText("Resources\\Spells.json");
            List<Spell> spells = JsonSerializer.Deserialize<List<Spell>>(json);
            if (spells == null) return null;
            return spells;
        }
    }
}
