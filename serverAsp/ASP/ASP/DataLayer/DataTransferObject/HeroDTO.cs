using ASP.DataLayer.Models;

namespace ASP.DataLayer.DataTransferObject
{
    public class HeroDTO
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Attribute { get; set; }
        public string Backstory { get; set; }
        public string PhotoUrl { get; set; }
        public string AttackType { get; set; }
        public string Complexity { get; set; }
        public List<PowerDTO>? PowerList { get; set; }
        public StatsDTO? Stats { get; set; }
        public RolesDTO? Roles { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }

    }
}
