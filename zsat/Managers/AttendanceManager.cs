using zsat.Interfaces;
using zsat.Models;

namespace zsat.Managers
{
    public class AttendanceManager : IAttendance
    {
        private readonly ZsatDbContext _context;

        public AttendanceManager(ZsatDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> RegisterAttendance(string cardId, DateTime timestamp)
        {
            Attendance attendance = new Attendance();
            attendance.CardUserId = cardId;
            attendance.Timestamp = timestamp;
            attendance.LessonId = 1;
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }
    }
}
