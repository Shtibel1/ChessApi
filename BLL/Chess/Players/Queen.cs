using BLL.Chess;
using BLL.Chess.Players;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Players
{
    public class Queen : IPlayer
    {
        public PlayerColor Color { get; set; }
        public string? Img { get; set; }
        public PlayerType Type { get; set; } = PlayerType.Queen;

        public Queen(PlayerColor color)
        {
            Color = color;
            if (Color == PlayerColor.White)
            {
                Img = "https://static.thenounproject.com/png/777774-512.png";
            }
            else
            {
                Img = "https://static.thenounproject.com/png/777775-512.png";
            }
        }
        public bool CanMove(int x, int y, int i, int j, Square[,] board)
        {

            var currentQueen = board[x, y].Player;
            if (currentQueen == null) return false;
            if ((x == i && y != j) || (y == j && x != i))
            {
                var rook = new Rook(currentQueen.Color);
                return rook.CanMove(x, y, i, j, board);
            }

            else if (Math.Abs(x - i) == Math.Abs(y - j))
            {
                var bishop = new Bishop( currentQueen.Color) ;
                return bishop.CanMove(x, y, i, j, board);
            }

            else return false;
        }
    }
}