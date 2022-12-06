using Microsoft.EntityFrameworkCore;
using zsat.Interfaces;
using zsat.Models;

namespace zsat.Managers
{
    public class StudentManager : IStudent
    {
        private readonly ZsatDbContext _context;

        public StudentManager(ZsatDbContext context)
        {
            _context = context;
        }

        public Student Add(Student student)
        {
            if (student != null) 
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return student;
            }
            throw new ArgumentNullException(nameof(student));
        }

        public Student DeleteByCardId(string cardId)
        {
            Student? foundStudent = _context.Students.Where(s => s.CardId == cardId).FirstOrDefault();
            if (foundStudent == null) throw new ArgumentNullException(nameof(foundStudent));
            _context.Students.Remove(foundStudent);
            _context.SaveChanges();
            return foundStudent;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetByCardId(string cardId)
        {
            Student? foundStudent = _context.Students.Where(s => s.CardId == cardId).FirstOrDefault();
            if (foundStudent == null) throw new ArgumentNullException(nameof(foundStudent));
            return foundStudent;
        }

        public Student Update(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            Student? foundStudent = _context.Students.Where(s => s.CardId == student.CardId).FirstOrDefault();
            if (foundStudent == null) throw new ArgumentNullException(nameof(foundStudent));
            foundStudent = student;
            _context.SaveChanges();
            return student;
        }
    }
}
