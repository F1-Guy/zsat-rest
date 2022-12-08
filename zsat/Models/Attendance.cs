using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        [Required]
        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        [Required]
        public string StudentCardId { get; set; }

        public Student Student { get; set; }
    }
}
