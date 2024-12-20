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

        public Teacher AddTeacher(Teacher teacher)
        {
            var json = File.ReadAllText("Resources\\Teachers.json");
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            int count = teachers.Select(t => t.id).Max();
            teacher.id = count + 1;
            teachers.Add(teacher);
            return teacher;
            
        }
    }
}
