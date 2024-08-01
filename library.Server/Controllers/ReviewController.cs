using library.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly AppDbContext _appDbContext;

        public ReviewController(ILogger<ReviewController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet("getAllReviewsById")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int id)
        {
            try
            {
                var reviews = await _appDbContext.Reviews
                        .Where(r => r.BookId == id)
                        .ToListAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving reviews.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("NewReview")]
        public async Task<ActionResult<Review>> CreateReview([FromBody] Review review)
        {
            try
            {
                _appDbContext.Reviews.Add(review);
                await _appDbContext.SaveChangesAsync();

                return CreatedAtRoute("GetAllReviewsById", new { id = review.Id }, review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the review.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
