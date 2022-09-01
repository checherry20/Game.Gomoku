using Game.Gomoku.Cache;
using Game.Gomoku.Infrastructure;
using Game.Gomoku.Models;
using Game.Gomoku.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Game.Gomoku.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class BoardController : ControllerBase
    {
        private readonly IInMemoryCache _inMemoryCache;
        private readonly IMovementChecker _movementChecker;

        public BoardController(IInMemoryCache inMemoryCache, IMovementChecker movementChecker )
        {
            _inMemoryCache = inMemoryCache;
            _movementChecker = movementChecker;
        }
        
        [HttpGet("create/{boardName}")]
        [Produces("application/json", Type = typeof(PlayerBoardModel))]
        public async Task<IActionResult> CreatePlayerBoard(string boardName)
        {
            if (_inMemoryCache.IsCacheExist(boardName))
                return BadRequest("Board already exist.");

            var board = new PlayerBoardModel() { BoardName = boardName };

            for (int n = 1; n <= 15; n++)
            {
                var firstChar = 'A';
                for (int l = 0; l < 16; l++)
                {
                    board.BoardPoints.Add($"{firstChar.MoveLetter(l)}{n}");
                }
            }

            _inMemoryCache.OnSet(boardName, board);
            return Ok(board);
        }

        [HttpGet("{boardName}/{point}/is-win/{colorStone}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> IsWin(string boardName, string point, PlayerStone? colorStone)
        {
            if (string.IsNullOrEmpty(boardName) || string.IsNullOrEmpty(point) || colorStone == null)
                return BadRequest();

            var board = _inMemoryCache.OnGet<PlayerBoardModel>(boardName);

            if (board == null)
                return BadRequest("Board does not exist. Please create a new board.");

            if(board.WhitePlayerPoints.Any(x => x == point) || board.BlackPlayerPoints.Any(x => x == point))
                return BadRequest("Position is already occupied.");
            
            var stone = new List<string>();
            if(colorStone == PlayerStone.White)
            {
                stone = board.WhitePlayerPoints;
                board.WhitePlayerPoints.Add(point);
            }
            else
            {
                stone = board.BlackPlayerPoints;
                board.BlackPlayerPoints.Add(point);
            }
            
            var isWin = _movementChecker.Check(stone, point);

            _inMemoryCache.OnUpdate<PlayerBoardModel>(boardName, board);

            if (isWin)
            {
                _inMemoryCache.OnRemoveCache(boardName);
            }
            return Ok(isWin);
        }

    }
}   