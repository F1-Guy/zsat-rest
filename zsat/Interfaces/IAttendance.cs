using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAttendance
    {
        public List<Attendance> GetAllAttendances();
        public Attendance GetById(int id);
        public Attendance RegisterAttendance(string cardId, DateTime timestamp, int lessonId);
        public Attendance DeleteAttendance(int aId);
        public List<Attendance> FilterByTime(DateTime startDate, DateTime? endDate);
    }
}
