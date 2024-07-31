using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OllieShop.Comment.Context;
using OllieShop.Comment.Dtos;

namespace OllieShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;
        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var comments = await _commentContext.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Entities.Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _commentContext.Comments.Add(comment);
            await _commentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Entities.Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _commentContext.Entry(comment).State = EntityState.Modified;

            try
            {
                await _commentContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(comment.CommentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentContext.Comments.Remove(comment);
            await _commentContext.SaveChangesAsync();

            return Ok("Comment Deleted Successfully");
        }

        [HttpGet("GetCommentsByProductId")]
        public async Task<IActionResult> GetCommentsByProductId(string productId)
        {
            var comments = await _commentContext.Comments
                                                .Where(c => c.ProductId == productId)
                                                .ToListAsync();

            if (!comments.Any())
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpGet("GetRatesByProductId")]
        public async Task<IActionResult> GetRatesByProductId(string productId)
        {
            var comments = await _commentContext.Comments.Where(c => c.ProductId == productId).ToListAsync();
            if (!comments.Any())
            {
                return NotFound();
            }
            return Ok(new RateStatisticsDto
            {
                AverageRate = comments.Average(c => c.Rate),
                TotalComments = comments.Count
            });
        }


        private bool CommentExists(int id)
        {
            return _commentContext.Comments.Any(e => e.CommentId == id);
        }
    }
}
