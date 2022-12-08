using zsat.Interfaces;
using zsat.Models;

namespace zsat.Managers
{
    public class LessonsManager : ILesson
    {

        private readonly ZsatDbContext _context;

        public LessonsManager(ZsatDbContext context)
        {
            _context = context;
        }

        public Lesson Add(Lesson lesson)
        {
            if (lesson != null)
            {
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                return lesson;
            }
            throw new ArgumentNullException(nameof(lesson));
        }

        public Lesson DeleteById(int id)
        {
            Lesson? foundLesson = _context.Lessons.Where(l => l.Id == id).FirstOrDefault();
            if (foundLesson == null) throw new ArgumentNullException(nameof(foundLesson));
            _context.Lessons.Remove(foundLesson);
            _context.SaveChanges();
            return foundLesson;
        }

        public List<Lesson> GetAll()
        {
            return _context.Lessons.ToList();
        }

        public Lesson GetById(int id)
        {
            Lesson? foundLesson = _context.Lessons.Where(l => l.Id == id).FirstOrDefault();
            if (foundLesson == null) throw new ArgumentNullException(nameof(foundLesson));
            return foundLesson;
        }

        public Lesson Update(Lesson lesson)
        {
            if (lesson == null) throw new ArgumentNullException(nameof(lesson));
            Lesson? foundLesson = _context.Lessons.Where(l => l.Id == lesson.Id).FirstOrDefault();
            if (foundLesson == null) throw new ArgumentNullException(nameof(foundLesson));
            foundLesson = lesson;
            _context.SaveChanges();
            return lesson;
        }

        
    }
}
