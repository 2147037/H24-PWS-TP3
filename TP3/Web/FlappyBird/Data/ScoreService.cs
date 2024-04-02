using FlappyBird.Models;
using Microsoft.EntityFrameworkCore;

namespace FlappyBird.Data
{
    public class ScoreService
    {
        protected readonly FlappyBirdContext _context;
        public ScoreService(FlappyBirdContext context)
        {
            _context = context;
        }

        public bool IsScoreSetEmpty()
        {
            return _context == null || _context.Score == null;
        }

        public async Task<IEnumerable<Score>?> GetAll()
        {
            if(IsScoreSetEmpty()) return null;

            return await _context.Score.ToListAsync();
        }

        public async Task<Score?> CreateScore(Score score)
        {
            if(IsScoreSetEmpty()) return null;

            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return score;
        } 

        public async Task<Score?> GetScore(int id)
        {
            return await _context.Score.FindAsync(id);
        }

        public async Task<Score?> UpdateScore(Score score)
        {

            if (IsScoreSetEmpty()) return null;

            score.IsPublic = !score.IsPublic;

            _context.ChangeTracker.Clear();
            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();



            return score;
        }
    }
}
