using GuideGoAPI.Data;
using GuideGoAPI.Entities;
using GuideGoAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuideGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly GuideContext _context;

        public ReviewsController(GuideContext context)
        {
            _context = context;
        }

        // GET: api/reviews
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _context.Reviews.ToListAsync();

            var reviewDtos = reviews.Select(review => new ReviewDTOResponse
            {
                ReviewId = review.ReviewId,
                GuideId = review.GuideId,
                TouristId = review.TouristId,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            }).ToList();

            return Ok(reviewDtos);
        }

        // GET: api/reviews/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            var reviewDto = new ReviewDTOResponse
            {
                ReviewId = review.ReviewId,
                GuideId = review.GuideId,
                TouristId = review.TouristId,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };

            return Ok(reviewDto);
        }

        // POST: api/reviews
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = new Review
            {
                GuideId = reviewDto.GuideId,
                TouristId = reviewDto.TouristId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = reviewDto.ReviewDate
            };

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            var reviewResponse = new ReviewDTOResponse
            {
                ReviewId = review.ReviewId,
                GuideId = review.GuideId,
                TouristId = review.TouristId,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };

            return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, reviewResponse);
        }

        // PUT: api/reviews/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO reviewDto)
        {
            var existingReview = await _context.Reviews.FindAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            existingReview.Rating = reviewDto.Rating;
            existingReview.Comment = reviewDto.Comment;
            existingReview.ReviewDate = reviewDto.ReviewDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/reviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
