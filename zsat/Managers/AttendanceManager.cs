using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> RegisterAttendance(string cardId, DateTime timestamp)
        {
            if (cardId == null) throw new ArgumentNullException(nameof(cardId));

            Attendance attendance = new Attendance();
            attendance.StudentCardId = cardId;
            attendance.Timestamp = timestamp;
            attendance.LessonId = 1;
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }
    }
}
