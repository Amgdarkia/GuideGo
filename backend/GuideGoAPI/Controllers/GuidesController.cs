using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuideGoAPI.Data;
using GuideGoAPI.Entities;

namespace GuideGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidesController : ControllerBase
    {
        private readonly GuideContext _context;

        public GuidesController(GuideContext context)
        {
            _context = context;
        }

        // GET: api/guides
        [HttpGet]
        public async Task<IActionResult> GetGuides()
        {
            var guides = await _context.Guides.ToListAsync();
            return Ok(guides);
        }

        // GET: api/guides/{id}
        [HttpGet("{id}")]   
        public async Task<IActionResult> GetGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return NotFound();
            }

            return Ok(guide);
        }

        // POST: api/guides
        [HttpPost]
        public async Task<IActionResult> CreateGuide([FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Guides.AddAsync(guide);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuide), new { id = guide.GuideId }, guide);
        }

        // PUT: api/guides/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuide(int id, [FromBody] Guide guide)
        {
            if (id != guide.GuideId)
            {
                return BadRequest("Guide ID mismatch.");
            }

            var existingGuide = await _context.Guides.FindAsync(id);
            if (existingGuide == null)
            {
                return NotFound();
            }

            existingGuide.FirstName = guide.FirstName;
            existingGuide.LastName = guide.LastName;
            existingGuide.Email = guide.Email;
            existingGuide.Password = guide.Password;
            existingGuide.Bio = guide.Bio;
            existingGuide.Country = guide.Country;
            existingGuide.PhoneNumber = guide.PhoneNumber;
            existingGuide.HasCar = guide.HasCar;
            existingGuide.AverageRating = guide.AverageRating;
            existingGuide.DateOfBirth = guide.DateOfBirth;
            existingGuide.Languages = guide.Languages;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/guides/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
