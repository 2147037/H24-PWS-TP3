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
using Microsoft.AspNetCore.Identity;

namespace FlappyBird.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        readonly UserManager<User> UserManager;
        private readonly ScoreService _scoreService;

        public ScoresController(UserManager<User> userManager, ScoreService scoreService)
        {
            this.UserManager = userManager;
            _scoreService = scoreService;
        }

        // GET: api/Scores

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            IEnumerable<Score> listeScore = await _scoreService.GetAll();

            return Ok(listeScore.Where(s => s.User != null).Where(x =>x.IsPublic).OrderByDescending(x=>x.ScoreValue).Take(10).Select(s => new ScoreDTO
            {
                Id = s.Id,
                ScoreValue = s.ScoreValue,
                Date  = s.Date,
                IsPublic = s.IsPublic,
                Pseudo = s.User!.UserName,
                TimeInSeconds = s.TimeInSeconds
            }));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) return Unauthorized();

            if (_scoreService.IsScoreSetEmpty()) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." });

            return user.Score;

        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));


            Score? score1 = await _scoreService.GetScore(id);

            if(score1 == null)
            {
                return NotFound();
            }

            if (user == null || score1.User != user)
            {
                return Unauthorized(new { Message = "Hey toche pas, c'est pas à toi !" });
            }

            Score? nvScore = await _scoreService.UpdateScore(score1);


            if (nvScore == null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." });
               


            return Ok( new { Message = " Score modifié", Score = nvScore});
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return Unauthorized();

            score.User = user;
            score.Date = DateTime.Now;

            Score? score1 = await _scoreService.CreateScore(score);

            if (score1 == null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." });
             
            return Ok(score);

            
        }

        
    }
}
