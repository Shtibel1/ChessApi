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
    public class Pawn : Player, IPlayer
    {
        public PlayerColor Color { get; set; }
        public string Img { get; set; }
        public PlayerType Type { get; set; } = PlayerType.Pawn;
        public Pawn(PlayerColor color)
        {
            this.Color = color;
            if (Color == PlayerColor.Black)
                this.Img = "https://www.svgrepo.com/show/7136/chess-pawn.svg";
            else
            {
                this.Img = "https://www.svgrepo.com/show/509814/chess-pawn.svg";
            }
        }

        public bool CanMove(int x, int y, int i, int j, Square[,] board, bool isCheck = false)
        {
            if (!isCheck) {
                var isNotThreatened = ChessHelper.IsKingNotThreatened(x, y, i, j, board, board[x, y].Player.Color);
                if (!isNotThreatened) return false;
            }
            if (Color == PlayerColor.White)
            {
                if (((i - x == 1 || (x == 1 && i - x == 2))) && y == j)
                {
                    for (int k = x + 1; k <= i; k++)
                    {
                        if (board[k, j]?.Player != null)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                if (Math.Abs(y - j) == 1 && i - x == 1 && 
                    board[i, j]?.Player?.Color != board[x, y]?.Player?.Color &&
                    board[i, j]?.Player != null) return true;
            }
            else
            {
                if ((x - i == 1 || (x == 6 && x - i == 2)) && y == j)
                {
                    for (int k = x - 1; k >= i; k--)
                    {
                        if (board[k, j]?.Player != null)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                if (Math.Abs(y - j) == 1 && x-i == 1 &&
                    board[i, j]?.Player?.Color != board[x, y]?.Player?.Color &&
                    board[i, j]?.Player != null) return true;
            }
            return false;
        }
        

        public override string ToString()
        {
            if (Color == PlayerColor.Black) { 
                return $"BP";
            }
            else
            {
                return "WP";
            }
        }
    }
}
