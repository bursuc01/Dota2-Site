using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public float Carry { get; set; }
        public float Support { get; set; }
        public float Nuker { get; set; }
        public float Disabler { get; set; }
        public float Jungler { get; set; }
        public float Durable { get; set; }
        public float Escape { get; set; }
        public float Pusher { get; set; }
        public float Initiator { get; set; }
        public int? HeroId { get; set; }
        public Hero? Hero { get; set; }
    }
}
