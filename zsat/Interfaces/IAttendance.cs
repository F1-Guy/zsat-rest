﻿using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAttendance
    {
        public List<Attendance> GetAllAttendances();
        public Attendance GetById(int id);
        public Tuple<List<Student>, List<Student>?> GetTodaysAttendance();
        public Attendance RegisterAttendance(string cardId, DateTime timestamp, int lessonId);
        public Attendance AddAttendance(string cardId, int lessonId);
        public Attendance DeleteAttendance(int aId);
        public List<Attendance> Filter(DateTime? startDate, int? lessonId, DateTime? endDate);
    }
}
