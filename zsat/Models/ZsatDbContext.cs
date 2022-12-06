using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace zsat.Models
{
    public class ZsatDbContext : DbContext
    {
        public ZsatDbContext()
        {
            
        }

        public ZsatDbContext(DbContextOptions<ZsatDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
    }
}
