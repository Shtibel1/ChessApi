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
    public class Bishop : Player, IPlayer
    {
        public PlayerColor Color { get; set; }
        public string? Img { get; set; }
        public PlayerType Type { get; set; } = PlayerType.Bishop;

        public Bishop(PlayerColor color)
        {
            Color = color;
            if (Color == PlayerColor.White)
            {
                Img = "https://static.thenounproject.com/png/4733152-512.png";
            }
            else
            {
                Img = "https://static.thenounproject.com/png/4862912-512.png";
            }
        }

        public bool CanMove(int x, int y, int i, int j, Square[,] board, bool isCheck = false)
        {
            if (!isCheck) {
                var isNotThreatened = ChessHelper.IsKingNotThreatened(x, y, i, j, board, board[x, y].Player.Color);
                if (!isNotThreatened) return false;
            }
            var currentPlayer = board[x, y];
            if (Math.Abs(x - i) != Math.Abs(y - j)) return false;
            var dirX = x < i ? 1 : -1;
            var dirY = y < j ? 1 : -1;
            x = x + dirX;
            y = y + dirY;
            while (x != i && y != j)
            {
                if (board[x, y].Player != null) return false;
                x = x + dirX;
                y = y + dirY;
            }
            if (board[i, j]?.Player?.Color == currentPlayer?.Player?.Color) return false;

            return true;
        }
    }
}
