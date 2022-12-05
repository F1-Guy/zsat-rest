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

namespace zsat.Managers.Tests
{
    [TestClass]
    public class AttendanceManagerTests
    {
        private readonly AttendanceManager _manager;
        public AttendanceManagerTests() { }
        public AttendanceManagerTests(AttendanceManager manager)
        {
            _manager = manager;
        }

        [TestMethod()]
        public void GetEmptyAttendancesTest()
        {
            //arrange
            _manager.RegisterAttendance("1", DateTime.Now);
            List<Attendance> attendances = new List<Attendance>();
            //act
            attendances = _manager.GetAllAttendances().Result;
            //assert
            Assert.AreEqual(1, attendances.Count);
        }

        [TestMethod]
        public void GetAllAttendancesTest()
        {
            //arrange
            List<Attendance> attendances = new List<Attendance>();
            //act
            attendances = _manager.GetAllAttendances().Result;
            //assert
            Assert.AreEqual(0, attendances.Count);        
        }

        [TestMethod]
        public void RegisterAttendanceTest()
        {
            //arrange
            string cardId = "2";
            DateTime timestamp = DateTime.Now;
            //act
            Attendance attendance = _manager.RegisterAttendance(cardId, timestamp).Result;
            List<Attendance> attendances = _manager.GetAllAttendances().Result;
            //assert
            Assert.AreEqual(2, attendances.Count);
        }
        [TestMethod]
        public void RegisterInvalidAttendanceTest()
        {
            Assert.Fail();
        }
    }
}