using BLL.Chess.Players;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Players
{
    public class Rook : Player, IPlayer
    {
        public PlayerColor Color { get; set; }
        public string? Img { get; set; }
        public PlayerType Type { get; set; } = PlayerType.Rook;

        public Rook(PlayerColor color)
        {
            Color = color;
            if (Color == PlayerColor.White)
            {
                Img = "https://static.thenounproject.com/png/3059699-512.png";
            }
            else
            {
                Img = "https://static.thenounproject.com/png/3059760-512.png";
            }
        }
        public bool CanMove(int x, int y, int i, int j, Square[,] board, bool isCheck = false)
        {

            if (!isCheck) { 
            
                var king = new King(board[x, y].Player.Color);
                var isNotThreatened = king.IsNotthreatened(x, y, i, j, board);
                if (!isNotThreatened) return false;
            }
            if (x != i && y != j) return false;
            if (x == i)
            {
                for (int k = Math.Min(y, j) + 1; k < Math.Max(y, j); k++)
                {
                    if (board[x, k]?.Player != null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int k = Math.Min(x, i) + 1; k < Math.Max(x, i); k++)
                {
                    if (board[k, y]?.Player != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
