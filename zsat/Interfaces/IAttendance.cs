using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAttendance
    {
        public Task<Attendance> RegisterAttendance(string cardId, DateTime timestamp);
        public Task<List<Attendance>> GetAllAttendances();
    }
}
