using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class Power
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PowerName { get; set; }
        [Required]
        public string PowerDescription { get; set; }
        [Required]
        public string PowerType { get; set; }
        [Required]
        public string Cooldown { get; set; }
        [Required]
        public string Backstory { get; set; }
        public string PowerImageUrl { get; set; }
        public string PowerVideoUrl { get; set; }
        public int? HeroId { get; set; }

    }
}
