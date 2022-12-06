using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class AuthUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
