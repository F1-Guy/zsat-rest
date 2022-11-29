using zsat.Models;

namespace zsat.Managers
{
    public class AttendancesManager
    {
        private readonly ZsatDbContext _context;

        public AttendancesManager(ZsatDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAttendance(string userId, DateTime timestamp)
        {
            Attendance attendance = new Attendance();
            attendance.AppUserId = userId;
            attendance.Timestamp = timestamp;
            attendance.LessonId = 1;
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
