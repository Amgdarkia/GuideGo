using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuideGoAPI.Data;
using GuideGoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using GuideGoAPI.DTOs;

namespace GuideGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly GuideContext _context;

        public RoutesController(GuideContext context)
        {
            _context = context;
        }

        // GET: api/routes
        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            var routes = await _context.Routes.ToListAsync(); // Removed Include(Guide)

            var routeDtos = routes.Select(route => new RouteDTOResponse
            {
                RouteId = route.RouteId,
                GuideId = route.GuideId,
                Description = route.Description,
                Duration = route.Duration,
                DifficultyLevel = route.DifficultyLevel,
                StartPoint = route.StartPoint,
                EndPoint = route.EndPoint,
                RouteType = route.RouteType
            }).ToList();

            return Ok(routeDtos);
        }

        // GET: api/routes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(r => r.RouteId == id); // No Include(Guide)

            if (route == null)
            {
                return NotFound();
            }

            var routeDto = new RouteDTOResponse
            {
                RouteId = route.RouteId,
                GuideId = route.GuideId,
                Description = route.Description,
                Duration = route.Duration,
                DifficultyLevel = route.DifficultyLevel,
                StartPoint = route.StartPoint,
                EndPoint = route.EndPoint,
                RouteType = route.RouteType
            };

            return Ok(routeDto);
        }

        // POST: api/routes
        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody] RouteDTO routeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guideExists = await _context.Guides.AnyAsync(g => g.GuideId == routeDto.GuideId);
            if (!guideExists)
            {
                return BadRequest("GuideId is invalid.");
            }

            var route = new Entities.Route
            {
                GuideId = routeDto.GuideId,
                Description = routeDto.Description,
                Duration = routeDto.Duration,
                DifficultyLevel = routeDto.DifficultyLevel,
                StartPoint = routeDto.StartPoint,
                EndPoint = routeDto.EndPoint,
                RouteType = routeDto.RouteType
            };

            await _context.Routes.AddAsync(route);
            await _context.SaveChangesAsync();

            var routeResponse = new RouteDTOResponse
            {
                RouteId = route.RouteId,
                GuideId = route.GuideId,
                Description = route.Description,
                Duration = route.Duration,
                DifficultyLevel = route.DifficultyLevel,
                StartPoint = route.StartPoint,
                EndPoint = route.EndPoint,
                RouteType = route.RouteType
            };

            return CreatedAtAction(nameof(GetRoute), new { id = route.RouteId }, routeResponse);
        }

        // PUT: api/routes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] RouteDTO routeDto)
        {
            var existingRoute = await _context.Routes.FindAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }

            existingRoute.Description = routeDto.Description;
            existingRoute.Duration = routeDto.Duration;
            existingRoute.DifficultyLevel = routeDto.DifficultyLevel;
            existingRoute.StartPoint = routeDto.StartPoint;
            existingRoute.EndPoint = routeDto.EndPoint;
            existingRoute.RouteType = routeDto.RouteType;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/routes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
