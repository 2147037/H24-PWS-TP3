using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlappyBird.Data;
using FlappyBird.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FlappyBird.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly FlappyBirdContext _context;

        public ScoresController(FlappyBirdContext context)
        {
            _context = context;
        }

        // GET: api/Scores

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
            return await _context.Score.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Score>> GeyMyScores()
        {
          
            return NoContent();
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {


            return NoContent();
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            if(_context.Score == null)
            {
                return Problem("Entity set 'FlappyBirdContext.Score' is null");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                score.Date = DateTime.Now;
                score.User = user;
                //user.Score.Add(score);

                _context.Score.Add(score);
                await _context.SaveChangesAsync();
                return Ok(score);
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new {Message = " Utilisateur non trouvé."});
        }

        
    }
}
