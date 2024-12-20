using System.Text.Json;

namespace Advanced_ASP.NET.Models
{
    public class TeacherModel
    {
        public Teacher GetTeacherById(int id)
        {
            var json = File.ReadAllText("Resources\\Teachers.json");
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            return teachers.Where(t => t.id == id).First();
        }
    }
}
