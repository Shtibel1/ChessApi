using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class KingTests
{
    [Fact]
    public void King_MoveOneSquare_AllDirections_AreLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, king);

        // All 8 directions
        Assert.True(king.CanMove(4, 4, 4, 5, board)); // right
        Assert.True(king.CanMove(4, 4, 4, 3, board)); // left
        Assert.True(king.CanMove(4, 4, 5, 4, board)); // up
        Assert.True(king.CanMove(4, 4, 3, 4, board)); // down
        Assert.True(king.CanMove(4, 4, 5, 5, board)); // up-right
        Assert.True(king.CanMove(4, 4, 5, 3, board)); // up-left
        Assert.True(king.CanMove(4, 4, 3, 5, board)); // down-right
        Assert.True(king.CanMove(4, 4, 3, 3, board)); // down-left
    }

    [Fact]
    public void King_MoveTwoSquares_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, king);

        var canMove = king.CanMove(4, 4, 4, 6, board);

        Assert.False(canMove);
    }

    [Fact]
    public void King_MoveTwoSquaresDiagonal_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, king);

        var canMove = king.CanMove(4, 4, 6, 6, board);

        Assert.False(canMove);
    }

    [Fact]
    public void King_CaptureOpponentPiece_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 4, king);
        TestBoardHelper.PlacePiece(board, 4, 5, enemyPiece);

        var canMove = king.CanMove(4, 4, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void King_CaptureOwnPiece_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        var friendlyPiece = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, king);
        TestBoardHelper.PlacePiece(board, 4, 5, friendlyPiece);

        var canMove = king.CanMove(4, 4, 4, 5, board);

        Assert.False(canMove);
    }

    [Fact]
    public void King_MoveToSameSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, king);

        var canMove = king.CanMove(4, 4, 4, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void King_FromCorner_HasLimitedMoves()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, king);

        // Only 3 valid moves from corner (0,0)
        Assert.True(king.CanMove(0, 0, 0, 1, board)); // right
        Assert.True(king.CanMove(0, 0, 1, 0, board)); // up
        Assert.True(king.CanMove(0, 0, 1, 1, board)); // diagonal
    }

    [Fact]
    public void King_FromEdge_HasLimitedMoves()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 4, king);

        // 5 valid moves from edge
        Assert.True(king.CanMove(0, 4, 0, 3, board)); // left
        Assert.True(king.CanMove(0, 4, 0, 5, board)); // right
        Assert.True(king.CanMove(0, 4, 1, 3, board)); // up-left
        Assert.True(king.CanMove(0, 4, 1, 4, board)); // up
        Assert.True(king.CanMove(0, 4, 1, 5, board)); // up-right
    }

    [Theory]
    [InlineData(4, 4, 4, 7)] // 3 squares horizontal
    [InlineData(4, 4, 7, 4)] // 3 squares vertical
    [InlineData(4, 4, 7, 7)] // 3 squares diagonal
    [InlineData(4, 4, 6, 5)] // Knight-like move
    public void King_LongMoves_AreIllegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var king = new King(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, king);

        var canMove = king.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.False(canMove);
    }
}
