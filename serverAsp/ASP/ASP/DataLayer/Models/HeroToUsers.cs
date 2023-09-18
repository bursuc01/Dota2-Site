using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class HeroToUsers
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HeroId { get; set; }
    }
}
