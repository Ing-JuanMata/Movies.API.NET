using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly APIDbContext _context;
        public MoviesController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] Movie newMovie)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            movie.Director = newMovie.Director;
            movie.Duration = newMovie.Duration;
            movie.Gender = newMovie.Gender;
            movie.Name = newMovie.Name;
            movie.Release_Year = newMovie.Release_Year;

            await _context.SaveChangesAsync();
            return Ok(movie);
        }
    }
}