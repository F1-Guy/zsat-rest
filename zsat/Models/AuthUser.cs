using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

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

        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }
    }
}
