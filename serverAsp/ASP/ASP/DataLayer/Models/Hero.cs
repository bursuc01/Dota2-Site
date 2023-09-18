using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Power { get; set; }
        [Required]
        public string Backstory { get; set; }

        public string Attribute { get; set; }
        public string PhotoUrl { get; set; }
        public string AttackType { get; set; }
        public string Complexity { get; set; }
        public List<Power>? PowerList { get; set; }
        public Stats? Stats { get; set; }
        public int? StatsId { get; set; }
        public Roles? Roles { get; set; }
        public int? RoleId { get; set; }
        public List<HeroToUsers> HeroToUsers { get; set; } = null!;

        // photo-details
        public string? Source { get; set; }
        public string? Image { get; set; }

    }
}
