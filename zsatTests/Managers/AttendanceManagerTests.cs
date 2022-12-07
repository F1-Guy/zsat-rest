using Microsoft.VisualStudio.TestTools.UnitTesting;
using zsat.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsat.Models;
using zsat.Interfaces;
using NuGet.Packaging.Signing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using zsat.Controllers;

namespace zsat.Managers.Tests
{
    [TestClass]
    public class AttendanceManagerTests
    {
        string _connectionString = "Data Source=tcp:zsatdb.database.windows.net,1433;Initial Catalog=zsattestdb;User Id=zsatadmin@zsatdb;Password=Zealand123$";
        ZsatDbContext _context;
        AttendanceManager _manager;

        public AttendanceManagerTests()
        {
            var options = new DbContextOptionsBuilder<ZsatDbContext>().UseSqlServer(_connectionString).Options;
            _context = new ZsatDbContext(options);
            _manager = new AttendanceManager(_context);
        }

        List<Attendance> attendances = new List<Attendance>();

        [TestInitialize]
        public void Initialize()
        {
            attendances = _context.Attendances.ToList();
            foreach (var item in attendances)
            {
                _context.Attendances.Remove(item);
                _context.SaveChanges();
            }
        }

        //GetAllAttendances() 
        [TestMethod]
        public void GetEmptyAttendancesTest()
        {
            attendances = _manager.GetAllAttendances();

            Assert.AreEqual(0, attendances.Count);
        }

        //RegisterAttendance
        [TestMethod]
        public void RegisterAttendanceTest()
        {
            string cardId = "1";
            int lessonId = 1;
            DateTime timestamp = DateTime.Now;

            _manager.RegisterAttendance(cardId, timestamp, lessonId);

            attendances = _manager.GetAllAttendances();

            Assert.AreEqual(1, attendances.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterInvalidAttendanceTest()
        {
            string cardId = null;
            DateTime timestamp = DateTime.Now;
            int lessonId = 0;

            _manager.RegisterAttendance(cardId, timestamp, lessonId);
        }

        //DeleteAttendance
        [TestMethod]
        public void DeleteAttendanceTest()
        {
            Attendance att = _manager.RegisterAttendance("1", DateTime.Now, 1);
            Attendance? toDelete = _context.Attendances.Where(a => a.Id == att.Id).FirstOrDefault();

            List<Attendance> attendances = _manager.GetAllAttendances();
            int expected = attendances.Count - 1;

            _context.Attendances.Remove(toDelete);
            _context.SaveChanges();

            List<Attendance> attendancesAfter = _manager.GetAllAttendances();
            int actual = attendancesAfter.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteInvalidIdTest()
        {
            int invalidId = 5;

            _manager.DeleteAttendance(invalidId);
        }

        //FilterAttendance
        [TestMethod]
        public void FilterAttendanceByTime()
        {
            Attendance attendance = _manager.RegisterAttendance("1", DateTime.Now, 1);
            DateTime outOfRange = new DateTime(2022, 10, 10);
            _manager.RegisterAttendance("1", outOfRange , 1);

            DateTime date = DateTime.Now;
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            DateTime endDate = new DateTime(date.Year, date.Month, 24);
            int lessonId = 1;

            List<Attendance> filteredList = _manager.Filter(startDate,lessonId, endDate);

            Assert.AreEqual(filteredList.First(), attendance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterByInvalidTime()
        {
            DateTime date = DateTime.Now;
            DateTime startDate = new DateTime(date.Year, date.Month, 31);
            DateTime endDate = new DateTime(date.Year, date.Month, 24);
            int lessonId = 1;

            _manager.Filter(startDate,lessonId, endDate);
        }

        [TestMethod]
        public void FilterByInvalidLessonId()
        {
            int lessonId = 12345678;

            List<Attendance> attendances = _manager.Filter(null, lessonId, null);

            Assert.AreEqual(0, attendances.Count);
        }
    }
}