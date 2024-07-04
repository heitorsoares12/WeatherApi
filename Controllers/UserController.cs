using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WeatherAppContext _context;

        public UserController(WeatherAppContext context)
        {
            _context = context;
        }

        [HttpGet("user")]
        public async Task<ActionResult<User>> GetUser(string cpf)
        {
            var user = await _context.Users
                .Include(u => u.FavoriteCities)
                .FirstOrDefaultAsync(u => u.CPF == cpf);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return Ok(user);
        }

        [HttpPost("user")]
        public async Task<ActionResult<User>> RegisterUser(string cpf)
        {
            var user = await _context.Users
                .Include(u => u.FavoriteCities)
                .FirstOrDefaultAsync(u => u.CPF == cpf);

            if (user != null)
            {
                return Conflict(new { message = "CPF já cadastrado." });
            }

            user = new User { CPF = cpf };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
        }

        [HttpPost("{userId}/favorites")]
        public async Task<ActionResult<FavoriteCity>> AddFavorite(int userId, string cityName)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var existingFavorite = await _context.FavoriteCities
                .FirstOrDefaultAsync(fc => fc.UserId == userId && fc.CityName == cityName);

            if (existingFavorite != null)
            {
                return Conflict(new { message = "Cidade já adicionada aos favoritos do usuário." });
            }

            var favoriteCity = new FavoriteCity { CityName = cityName, UserId = userId };
            _context.FavoriteCities.Add(favoriteCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddFavorite), new { id = favoriteCity.Id }, favoriteCity);
        }

        [HttpGet("{userId}/favorites")]
        public async Task<ActionResult<IEnumerable<FavoriteCityDto>>> GetFavoriteCities(int userId)
        {
            var favoriteCities = await _context.FavoriteCities
                .Where(fc => fc.UserId == userId)
                .Select(fc => new FavoriteCityDto
                {
                    CityName = fc.CityName
                })
                .ToListAsync();

            return Ok(favoriteCities);
        }
    }
}
