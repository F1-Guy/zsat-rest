using zsat.Models;

namespace zsat.Interfaces
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetByCardId(string cardId);
        public Student Add(Student student);
        public Student Update(Student student);
        public Student DeleteByCardId(string cardId);
        public List<Attendance> GetStudentAttendances(string id);
    }
}
