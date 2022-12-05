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

        AppUser user1 = new AppUser() { Name = "Digna", Email = "dign0009@edu.zealand.dk" };
        CardUser cardUser1 = new CardUser() { CardId = "1" , AppUserId = "33f88254-954b-4633-a80c-8cc0fca880fd" };
        Lesson lesson1 = new Lesson() { Id = 1, Subject = "Math" };

        List<Attendance> attendances = new List<Attendance>();

        //public void Initialize()
        //{
        //    _context.AppUsers.Add(user1);
        //    _context.CardUsers.Add(cardUser1);
        //    _context.Lessons.Add(lesson1);
        //    _context.SaveChanges();
        //}

        [TestMethod]
        public void GetEmptyAttendancesTest()
        { 
            attendances = _manager.GetAllAttendances().Result;

            Assert.AreEqual(0, attendances.Count);
        }

        [TestMethod]
        public void GetAllAttendancesTest()
        {
            Attendance attendance = new Attendance() { CardUserId = cardUser1.CardId, LessonId = 1 };
            _context.Attendances.Add(attendance);

            attendances = _manager.GetAllAttendances().Result;

            Assert.AreEqual(1, attendances.Count);
        }

        [TestMethod]
        public void RegisterAttendanceTest()
        {
            string cardId = "1";
            DateTime timestamp = DateTime.Now;

            Attendance attendance = _manager.RegisterAttendance(cardId, timestamp).Result;
            List<Attendance> attendances = _manager.GetAllAttendances().Result;

            Assert.AreEqual(2, attendances.Count);
        }

        [TestMethod]
        public void RegisterInvalidAttendanceTest()
        {
            Assert.Fail();
        }
    }
}