using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public int AppUserId { get; set; }

        public Lesson Lesson { get; set; }

        public AppUser AppUser { get; set; }
    }
}
