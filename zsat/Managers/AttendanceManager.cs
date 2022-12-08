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
            return _context.Attendances.ToList();
        }

        public Attendance GetById(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault();

            if (attendance == null) throw new ArgumentException();

            return attendance;
        }

        public Attendance RegisterAttendance(string cardId, DateTime timestamp, int lessonId)
        {
            if ((cardId == null) || (lessonId == 0) || (timestamp == DateTime.MinValue))
            {
                throw new ArgumentException();
            }

            List<Attendance> att = _context.Attendances.Where(a => a.StudentCardId == cardId).ToList();
            att.Sort((x, y) => DateTime.Compare(x.CheckIn, y.CheckIn));
            Attendance? lastAttendance = att.LastOrDefault();

            Attendance attendance = new Attendance();

            if (lastAttendance == null || lastAttendance.CheckIn.Date != timestamp.Date)
                attendance.CheckIn = timestamp;

            else if (lastAttendance.CheckOut == null && lastAttendance.CheckIn == timestamp.Date)
            {
                lastAttendance.CheckOut = timestamp;
                _context.SaveChanges();
                return lastAttendance;
            }

            else
                throw new ArgumentException();

            attendance.StudentCardId = cardId;
            attendance.LessonId = lessonId;

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return attendance;
        }

        public Attendance DeleteAttendance(int aId)
        {
            Attendance attendance = GetById(aId);
            if (attendance == null) throw new ArgumentException();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return attendance;
        }

        public List<Attendance> Filter(DateTime? startDate, int? lessonId, DateTime? endDate)
        {
            List<Attendance> attendances = _context.Attendances.ToList();

            if (startDate != DateTime.MinValue || endDate != DateTime.MinValue)
            {
                DateTime minStartDate = new DateTime(2022, 09, 01);

                if (endDate == DateTime.MinValue) endDate = DateTime.Now;
                if (startDate == DateTime.MinValue) startDate = minStartDate;

                if (startDate > endDate || startDate < minStartDate) throw new ArgumentException();

                attendances = attendances.Where(a => a.CheckIn >= startDate).ToList();
                attendances = attendances.Where(a => a.CheckIn <= endDate).ToList();
            }

            if (lessonId != 0)
                attendances = attendances.Where(a => a.LessonId == lessonId).ToList();

            return attendances;
        }

    }
}
