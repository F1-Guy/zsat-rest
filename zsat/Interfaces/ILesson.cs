using zsat.Models;

namespace zsat.Interfaces
{
    public interface ILesson
    {
        public List<Lesson> GetAll();
        public Lesson GetById(int id);
        public Lesson Add(Lesson lesson);
        public Lesson Update(Lesson lesson);
    }
}
