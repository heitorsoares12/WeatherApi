using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [JsonIgnore]
        public ICollection<FavoriteCity> FavoriteCities { get; set; }
    }
}
