using System.ComponentModel.DataAnnotations;

namespace zsat.Models
{
    public class CardUser
    {
        [Key]
        public string CardId { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
