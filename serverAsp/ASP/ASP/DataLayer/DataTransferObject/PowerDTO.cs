using System.ComponentModel.DataAnnotations;

namespace ASP.DataLayer.DataTransferObject
{
    public class PowerDTO
    {
        public string PowerName { get; set; }
        public string PowerDescription { get; set; }
        public string PowerType { get; set; }
        public string Cooldown { get; set; }
        public string Backstory { get; set; }
        public string PowerImageUrl { get; set; }

        public string PowerVideoUrl { get; set; }

    }
}
