using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class QueenTests
{
    [Fact]
    public void Queen_MoveHorizontal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 0, queen);

        var canMove = queen.CanMove(4, 0, 4, 7, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Queen_MoveVertical_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 4, queen);

        var canMove = queen.CanMove(0, 4, 7, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Queen_MoveDiagonal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, queen);

        var canMove = queen.CanMove(0, 0, 7, 7, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Queen_MoveHorizontal_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 0, queen);
        TestBoardHelper.PlacePiece(board, 4, 3, blockingPiece);

        var canMove = queen.CanMove(4, 0, 4, 7, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Queen_MoveVertical_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 4, queen);
        TestBoardHelper.PlacePiece(board, 3, 4, blockingPiece);

        var canMove = queen.CanMove(0, 4, 7, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Queen_MoveDiagonal_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 0, queen);
        TestBoardHelper.PlacePiece(board, 3, 3, blockingPiece);

        var canMove = queen.CanMove(0, 0, 7, 7, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Queen_CaptureOpponentPiece_Horizontal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 0, queen);
        TestBoardHelper.PlacePiece(board, 4, 5, enemyPiece);

        var canMove = queen.CanMove(4, 0, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Queen_CaptureOpponentPiece_Diagonal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 0, queen);
        TestBoardHelper.PlacePiece(board, 5, 5, enemyPiece);

        var canMove = queen.CanMove(0, 0, 5, 5, board);

        Assert.True(canMove);
    }

    [Theory]
    [InlineData(4, 4, 5, 6)] // L-shape like knight
    [InlineData(4, 4, 6, 5)] // L-shape
    [InlineData(4, 4, 6, 7)] // Not on straight line or diagonal
    public void Queen_InvalidMoves_AreIllegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, queen);

        var canMove = queen.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Queen_MoveToSameSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, queen);

        var canMove = queen.CanMove(4, 4, 4, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Queen_MoveOneSquare_AllDirections_AreLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var queen = new Queen(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, queen);

        // All 8 directions
        Assert.True(queen.CanMove(4, 4, 4, 5, board)); // right
        Assert.True(queen.CanMove(4, 4, 4, 3, board)); // left
        Assert.True(queen.CanMove(4, 4, 5, 4, board)); // up
        Assert.True(queen.CanMove(4, 4, 3, 4, board)); // down
        Assert.True(queen.CanMove(4, 4, 5, 5, board)); // up-right
        Assert.True(queen.CanMove(4, 4, 5, 3, board)); // up-left
        Assert.True(queen.CanMove(4, 4, 3, 5, board)); // down-right
        Assert.True(queen.CanMove(4, 4, 3, 3, board)); // down-left
    }
}
