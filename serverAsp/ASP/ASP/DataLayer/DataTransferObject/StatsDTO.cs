using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.DataTransferObject
{
    public class StatsDTO
    {
        public float Attack { get; set; }
        public float AttackSpeed { get; set; }
        public float Range { get; set; }
        public float Armor { get; set; }
        public float MagicResist { get; set; }
        public float MoveSpeed { get; set; }
        public float Visibility { get; set; }
        public int? HeroId { get; set; }
    }
}
