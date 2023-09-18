using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public float Attack { get; set; }
        public float AttackSpeed { get; set; }
        public float Range { get; set; }

        public float Armor { get; set; }
        public float MagicResist { get; set; }

        public float MoveSpoeed { get; set; }
        public float Visibility { get; set; }

        public int? HeroId { get; set; }
        public Hero? Hero { get; set; }

    }
}
