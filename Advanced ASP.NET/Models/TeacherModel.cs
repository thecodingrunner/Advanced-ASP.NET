using System.Text.Json;

namespace Advanced_ASP.NET.Models
{
    public class TeacherModel
    {
        string teachersPath = "Resources\\Teachers.json";
        public Teacher GetTeacherById(int id)
        {
            var json = File.ReadAllText(teachersPath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            return teachers.Where(t => t.id == id).First();
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            var json = File.ReadAllText(teachersPath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            int count = teachers.Select(t => t.id).Max();
            teacher.id = count + 1;
            teachers.Add(teacher);
            File.WriteAllText(teachersPath, JsonSerializer.Serialize(teachers, new JsonSerializerOptions() { WriteIndented = true }));
            return teacher;
        }

        public Teacher? DeleteTeacher(int id)
        {
            var json = File.ReadAllText(teachersPath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            Teacher teacherToDelete = teachers.Where(t => t.id == id).First();
            if (teacherToDelete == null) return null;
            teachers.Remove(teacherToDelete);
            File.WriteAllText(teachersPath, JsonSerializer.Serialize(teachers, new JsonSerializerOptions() { WriteIndented = true }));
            return teacherToDelete;
        }

        public List<Teacher> GetAllTeachers()
        {
            var json = File.ReadAllText(teachersPath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);

            return teachers;
        }

        public Teacher? PatchTeachers(int id)
        {
            var json = File.ReadAllText(teachersPath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            
            var teacherToPatch = teachers.FirstOrDefault(x => x.id == id);
            if (teacherToPatch == null)
            {
                return null;
            }
            teacherToPatch.rating += 1;

            return teacherToPatch;
            
        }
    }
}
