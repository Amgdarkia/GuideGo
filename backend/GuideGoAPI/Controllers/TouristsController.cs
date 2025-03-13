using GuideGoAPI.Data;
using GuideGoAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuideGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristsController : ControllerBase
    {

        private readonly GuideContext _context;


        public TouristsController(GuideContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetTourists()
        {
            var Tourists = await _context.Tourists.ToListAsync();
            return Ok(Tourists);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourist(int id)
        {
            var tourist = await _context.Tourists.FindAsync(id);
            if (tourist == null)
            {
                return NotFound();
            }
            return Ok(tourist);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTourist([FromBody] Tourist tourist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.Tourists.AddAsync(tourist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTourist), new { id = tourist.TouristId }, tourist);
        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateTourist(int id, [FromBody] Tourist tourist)
        {
            if(id != tourist.TouristId)
            {
                return BadRequest("Tourist ID mismatch");
            }
            var existingTourist = await _context.Tourists.FindAsync(id);
            if(existingTourist == null)
            {
                return NotFound();
            }
            existingTourist.FirstName = tourist.FirstName;
            existingTourist.LastName = tourist.LastName;
            existingTourist.PhoneNumber = tourist.PhoneNumber;
            existingTourist.DateOfBirth = tourist.DateOfBirth;
            existingTourist.Country = tourist.Country;
            existingTourist.Email = tourist.Email;
            existingTourist.Password = tourist.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourist(int id)
        {
            var tourist = await _context.Tourists.FindAsync(id);
            if(tourist == null)
            {
                return NotFound();
            }
            _context.Tourists.Remove(tourist);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
