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
    public class King : Player, IPlayer
    {
        public PlayerColor Color { get; set; }
        public string? Img { get; set; }
        public PlayerType Type { get; set; } = PlayerType.King;

        public King(PlayerColor color)
        {
            Color = color;
            if (Color == PlayerColor.White)
            {
                Img = "https://static.thenounproject.com/png/4733156-512.png";
            }
            else
            {
                Img = "https://static.thenounproject.com/png/4862911-512.png";
            }
        }

        public bool CanMove(int x, int y, int i, int j, Square[,] board, bool isCheck = false)
        {
            if (!isCheck) {

                var isNotThreatened = ChessHelper.IsKingNotThreatened(x, y, i, j, board, board[x, y].Player.Color);
                if (!isNotThreatened) return false;
            }

            if ((Math.Abs(x - i) < 2 && 
                Math.Abs(y - j) < 2) && 
                board[x, y]?.Player.Color != board[i, j]?.Player?.Color) return true;
            return false;
        }

        
    }
}
