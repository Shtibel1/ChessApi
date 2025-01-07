using BLL;
using BLL.Chess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly ChessService _chessService;

        public ChessController(ChessService chessService)
        {
            _chessService = chessService;
        }

        [HttpGet]
        public IActionResult GetBoard()
        {
            var board = _chessService.ConvertToJaggedArray(_chessService.Board);
            return Ok(board);
        }

        [HttpPost("move")]
        public IActionResult Move(MoveModel move)
        {
            var result = _chessService.Move(move.X, move.Y, move.I, move.J);
            if (!result) return BadRequest();
            return Ok();
        }
        
    }

 
    public class MoveModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int I { get; set; }
        public int J { get; set; }
    }
}
