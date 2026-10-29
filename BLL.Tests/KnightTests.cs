using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class KnightTests
{
    [Theory]
    [InlineData(4, 4, 6, 5)] // +2 row, +1 col
    [InlineData(4, 4, 6, 3)] // +2 row, -1 col
    [InlineData(4, 4, 2, 5)] // -2 row, +1 col
    [InlineData(4, 4, 2, 3)] // -2 row, -1 col
    [InlineData(4, 4, 5, 6)] // +1 row, +2 col
    [InlineData(4, 4, 5, 2)] // +1 row, -2 col
    [InlineData(4, 4, 3, 6)] // -1 row, +2 col
    [InlineData(4, 4, 3, 2)] // -1 row, -2 col
    public void Knight_AllLShapeMoves_ToEmptySquare_AreLegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, knight);

        var canMove = knight.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Knight_JumpsOverPieces_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 1, knight);
        
        // Place blocking pieces around the knight
        TestBoardHelper.PlacePiece(board, 0, 0, new Pawn(PlayerColor.White));
        TestBoardHelper.PlacePiece(board, 0, 2, new Pawn(PlayerColor.White));
        TestBoardHelper.PlacePiece(board, 1, 0, new Pawn(PlayerColor.Black));
        TestBoardHelper.PlacePiece(board, 1, 1, new Pawn(PlayerColor.Black));
        TestBoardHelper.PlacePiece(board, 1, 2, new Pawn(PlayerColor.Black));

        var canMove = knight.CanMove(0, 1, 2, 2, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Knight_CapturesOpponentPiece_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 4, knight);
        TestBoardHelper.PlacePiece(board, 6, 5, enemyPiece);

        var canMove = knight.CanMove(4, 4, 6, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Knight_CapturesOwnPiece_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        var friendlyPiece = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, knight);
        TestBoardHelper.PlacePiece(board, 6, 5, friendlyPiece);

        var canMove = knight.CanMove(4, 4, 6, 5, board);

        Assert.False(canMove);
    }

    [Theory]
    [InlineData(4, 4, 5, 5)] // 1,1 diagonal
    [InlineData(4, 4, 6, 6)] // 2,2 diagonal
    [InlineData(4, 4, 4, 6)] // horizontal
    [InlineData(4, 4, 6, 4)] // vertical
    [InlineData(4, 4, 4, 4)] // same square
    public void Knight_NonLShapeMoves_AreIllegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, knight);

        var canMove = knight.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Knight_FromCorner_HasLimitedMoves()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, knight);

        // Valid moves from corner (0,0) are only (1,2) and (2,1)
        Assert.True(knight.CanMove(0, 0, 1, 2, board));
        Assert.True(knight.CanMove(0, 0, 2, 1, board));
    }

    [Fact]
    public void Knight_FromEdge_HasLimitedMoves()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var knight = new Knight(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 4, knight);

        // Valid moves from (0,4)
        Assert.True(knight.CanMove(0, 4, 1, 6, board));
        Assert.True(knight.CanMove(0, 4, 1, 2, board));
        Assert.True(knight.CanMove(0, 4, 2, 5, board));
        Assert.True(knight.CanMove(0, 4, 2, 3, board));
    }
}
