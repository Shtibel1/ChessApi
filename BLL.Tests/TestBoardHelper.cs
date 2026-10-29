using BLL;
using BLL.Enums;
using BLL.Players;

namespace BLL.Tests;

public static class TestBoardHelper
{
    public static Square[,] CreateEmptyBoard()
    {
        var board = new Square[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = new Square();
            }
        }
        return board;
    }

    public static void PlacePiece(Square[,] board, int row, int col, IPlayer piece)
    {
        board[row, col].Player = piece;
    }
}
