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
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DELETE * FROM Attendances", conn);

        } 

        [TestMethod]
        public void GetEmptyAttendancesTest()
        { 
            attendances = _manager.GetAllAttendances().Result;

            Assert.AreEqual(0, attendances.Count);
        }

        [TestMethod]
        public void GetAllAttendancesTest()
        {
            string cardId = "1";
            DateTime timestamp = DateTime.Now;

            _manager.RegisterAttendance(cardId, timestamp);
        
            attendances = _manager.GetAllAttendances().Result;

            Assert.AreEqual(1, attendances.Count);
        }

        [TestMethod]
        public void RegisterInvalidAttendanceTest()
        {
            Assert.Fail();
        }
    }
}