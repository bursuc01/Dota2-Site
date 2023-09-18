using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<HeroToUsers> HeroToUsers { get; set; }

    }
}
