using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace zsat.Models
{
    public class ZsatDbContext : IdentityDbContext<AppUser>
    {
        public ZsatDbContext()
        {
            
        }

        public ZsatDbContext(DbContextOptions<ZsatDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
    }
}
