using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAttendance
    {
        public Task<Attendance> RegisterAttendance(string userId, DateTime timestamp);
    }
}
