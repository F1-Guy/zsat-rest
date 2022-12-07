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

        public List<Attendance> GetAllAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }

        public Attendance GetById(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault();

            if (attendance == null) throw new ArgumentException();

            return attendance;
        }

        public Attendance RegisterAttendance(string cardId, DateTime timestamp, int lessonId)
        {
            if ((cardId == null) || (lessonId == 0))
            {
                throw new ArgumentException();
            }

            Attendance attendance = new Attendance();
            attendance.StudentCardId = cardId;
            attendance.Timestamp = timestamp;
            attendance.LessonId = lessonId;
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return attendance;
        }

        public Attendance DeleteAttendance (int aId)
        {
            Attendance attendance = GetById(aId);
            if (attendance == null) throw new ArgumentException();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return attendance;
        }

        public List<Attendance> FilterByTime(DateTime startDate, DateTime? endDate)
        {
            List<Attendance> filteredAttendance = new List<Attendance>();

            if (endDate == null) endDate = DateTime.Now;

            DateTime minStartDate = new DateTime(2022, 09, 01);

            if (startDate > endDate || startDate < minStartDate) throw new ArgumentException();

            foreach(var item in _context.Attendances.ToList())
            {
                if(item.Timestamp > startDate && item.Timestamp < endDate)
                {
                    filteredAttendance.Add(item);
                }
            }
            return filteredAttendance;
        }

    }
}
