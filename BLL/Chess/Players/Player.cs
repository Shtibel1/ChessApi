using BLL.Chess;
using BLL.Chess.Players;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Players
{
    public class Player
    {
        public Square[,] Move(int x, int y, int i, int j, Square[,] board)
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

        public bool CheckNotThreatened(int x, int y, int i, int j, Square[,] board, PlayerColor color)
        {
            return ChessHelper.IsNotThreatened(x, y, i, j, board, color);
        }
    }
}
