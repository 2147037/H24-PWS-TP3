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
            IEnumerable<Score> listeScore = await _context.Score.ToListAsync();

            return Ok(listeScore.Where(s => s.User != null).Where(x =>x.IsPublic).OrderByDescending(x=>x.ScoreValue).Take(10).Select(s => new ScoreDTO
            {
                Id = s.Id,
                ScoreValue = s.ScoreValue,
                Date  = s.Date,
                IsPublic = s.IsPublic,
                Pseudo = s.User!.UserName,
                TimeInSeconds = s.TimeInSeconds
            }));
                //await _context.Score.Where(x=>x.IsPublic == true).OrderBy(x=>x.ScoreValue).Take(10).ToListAsync();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                return await _context.Score.Where(x=>x.User == user).ToListAsync();
            }

            return NoContent();
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {
            Score score = await _context.Score.FindAsync(id);
            if (score != null)
            {
                score.IsPublic = !score.IsPublic;
                await _context.SaveChangesAsync();
                return Ok();
            }


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
