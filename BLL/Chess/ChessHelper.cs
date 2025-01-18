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

            var newBoard = MovePlayer(x, y, i, j, board);

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
                        if (newBoard[k, h].Player.CanMove(k, h, kingX, kingY, newBoard))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static Square[,] MovePlayer(int x, int y, int i, int j, Square[,] board)
        {
            var newBoard = new Square[board.GetLength(0), board.GetLength(1)];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    newBoard[row, col] = new Square
                    {
                        Player = board[row, col].Player,
                    };
                }
            }
            var player = newBoard[x, y].Player;
            newBoard[x, y].Player = null;
            newBoard[i, j].Player = player;

            return newBoard;
        }
    }
}
