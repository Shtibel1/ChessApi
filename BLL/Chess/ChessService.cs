using BLL.Enums;
using BLL.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chess
{
    public class ChessService
    {
        public Square[,] Board { get; set; } = new Square[8, 8];

        public ChessService()
        {
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = new Square();
                }
            }

            for (int i = 1; i < Board.GetLength(0); i = i + 5)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var color = i == 1 ? PlayerColor.White : PlayerColor.Black;
                    Board[i, j].Player = new Pawn(color);
                }
            }

            Board[0, 0].Player = new Rook(PlayerColor.White);
            Board[0, 7].Player = new Rook(PlayerColor.White);
            Board[7, 7].Player = new Rook(PlayerColor.Black);
            Board[7, 0].Player = new Rook(PlayerColor.Black);

            Board[0, 1].Player = new Knight(PlayerColor.White);
            Board[0, 6].Player = new Knight(PlayerColor.White);
            Board[7, 1].Player = new Knight(PlayerColor.Black);
            Board[7, 6].Player = new Knight(PlayerColor.Black);
            
            Board[0, 2].Player = new Bishop(PlayerColor.White);
            Board[0, 5].Player = new Bishop(PlayerColor.White);
            Board[7, 2].Player = new Bishop(PlayerColor.Black);
            Board[7, 5].Player = new Bishop(PlayerColor.Black);

            Board[0, 3].Player = new Queen(PlayerColor.White);
            Board[7, 3].Player = new Queen(PlayerColor.Black);
            
            Board[0, 4].Player = new King(PlayerColor.White);
            Board[7, 4].Player = new King(PlayerColor.Black);
        }

        public bool Move(int x, int y, int i, int j)
        {
            if (Board[x, y]?.Player == null) return false;
            if (Board[x,y]?.Player?.Color == Board[i,j]?.Player?.Color) return false;
            var isNotThreatened = ChessHelper.IsKingNotThreatened(x, y, i, j, Board, Board[x, y].Player.Color);
            if (!isNotThreatened) return false;
            if (Board[x, y].Player.CanMove(x, y, i, j, Board))
            {
                Board = ChessHelper.MovePlayer(x, y, i, j, Board);
                return true;
            }

            return false;
        }

        public Square[][] ConvertToJaggedArray(Square[,] multiArray)
        {
            int rows = multiArray.GetLength(0);
            int cols = multiArray.GetLength(1);

            var jaggedArray = new Square[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new Square[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = multiArray[i, j];
                }
            }

            return jaggedArray;
        }

        
    }
}
