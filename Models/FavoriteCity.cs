using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class FavoriteCity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        [JsonIgnore]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
