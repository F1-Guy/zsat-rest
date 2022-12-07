using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
    }
}
