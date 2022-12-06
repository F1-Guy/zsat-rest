using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class Student
    {
        [Key]
        public string CardId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(30)]
        public string? Course { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }
    }
}
