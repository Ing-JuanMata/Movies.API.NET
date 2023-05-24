using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DirectorController : Controller
    {
        private readonly APIDbContext _context;
        public DirectorController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await _context.Director.ToListAsync();
            return Ok(directors);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDirectorById([FromRoute] int id)
        {
            var director = await _context.Director.FirstOrDefaultAsync(x => x.Id == id);
            if (director == null)
                return NotFound();

            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Director director)
        {
            await _context.Director.AddAsync(director);
            await _context.SaveChangesAsync();
            return Ok(director);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Director newDirector)
        {
            var director = await _context.Director.FindAsync(id);

            if (director == null)
                return NotFound();

            director.Name = newDirector.Name;
            director.Active = newDirector.Active;
            director.Age = newDirector.Age;
            director.Nationality = newDirector.Nationality;

            await _context.SaveChangesAsync();
            return Ok(director);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDirector([FromRoute] int id)
        {
            var director = await _context.Director.FindAsync(id);

            if (director == null)
                return NotFound();

            _context.Director.Remove(director);
            await _context.SaveChangesAsync();
            return Ok(director);

        }
    }
}