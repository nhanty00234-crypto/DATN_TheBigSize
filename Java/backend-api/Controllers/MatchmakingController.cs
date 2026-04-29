using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchmakingController : ControllerBase
    {
        [HttpGet("matches")]
        public async Task<IActionResult> GetMatches()
        {
            // Get all available matches
            return Ok();
        }

        [HttpGet("matches/{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            // Get match details
            return Ok();
        }

        [HttpPost("matches")]
        public async Task<IActionResult> CreateMatch([FromBody] CreateMatchRequest request)
        {
            // Create new match
            return Ok();
        }

        [HttpPost("find-opponent")]
        public async Task<IActionResult> FindOpponent([FromBody] FindOpponentRequest request)
        {
            // Algorithm to find best opponent using ELO rating
            return Ok();
        }
    }

    public class CreateMatchRequest
    {
        public int AccountId { get; set; }
        public int OpponentId { get; set; }
        public int SanId { get; set; }
    }

    public class FindOpponentRequest
    {
        public int AccountId { get; set; }
        public int RatingRange { get; set; }
    }
}
