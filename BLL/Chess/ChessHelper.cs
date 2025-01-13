using BLL.Chess.Players;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chess
{
    public static class ChessHelper
    {
        public static bool IsKingNotThreatened(int x, int y, int i, int j, Square[,] board, PlayerColor color)
        {
            var kingX = 0;
            var kingY = 0;

            var newBoard = board[x, y].Player.Move(x, y, i, j, board);

            for (int k = 0; k < 8; k++)
            {
                for (int h = 0; h < 8; h++)
                {
                    if (newBoard[k, h]?.Player?.Type == PlayerType.King && newBoard[k, h]?.Player?.Color == color)
                    {
                        kingX = k;
                        kingY = h;
                    }
                }
            }

            for (int k = 0; k < 8; k++)
            {
                for (int h = 0; h < 8; h++)
                {
                    if (newBoard[k, h]?.Player != null && newBoard[k, h].Player.Color != color)
                    {
                        if (newBoard[k, h].Player.CanMove(k, h, kingX, kingY, newBoard, true))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
