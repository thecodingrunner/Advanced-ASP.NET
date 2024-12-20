using Advanced_ASP.NET.Models;

namespace Advanced_ASP.NET.Services
{
    public class TeacherService
    {
        private readonly TeacherModel _teacherModel;

        public TeacherService(TeacherModel teacherModel)
            {
              _teacherModel = teacherModel;
            }
        
        public Teacher GetTeacherById(int id)
        {
            return _teacherModel.GetTeacherById(id);
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            return _teacherModel.AddTeacher(teacher);
        }

        public Teacher? DeleteTeacher(int id)
        {
            return _teacherModel.DeleteTeacher(id);
        }
    }
}
