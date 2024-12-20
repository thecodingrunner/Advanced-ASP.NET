using System.Text.Json;

namespace Advanced_ASP.NET.Models
{
    public class SpellModel
    {
        public Spell? FetchRandomSpell()
        {
            var json = File.ReadAllText("Resources\\Spells.json");
            List<Spell> spells = JsonSerializer.Deserialize<List<Spell>>(json);
            var random = new Random();
            int index = (int)Math.Floor((decimal)random.Next(0, spells.Count));
            Spell spell = spells[index];
            if (spell == null) return null;
            return spell;
        }

       
    }
    
}
