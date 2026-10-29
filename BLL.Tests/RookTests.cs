using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class RookTests
{
    [Fact]
    public void Rook_MoveHorizontalRight_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, rook);

        var canMove = rook.CanMove(0, 0, 0, 7, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveHorizontalLeft_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 7, rook);

        var canMove = rook.CanMove(4, 7, 4, 0, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveVerticalUp_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, rook);

        var canMove = rook.CanMove(0, 0, 7, 0, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveVerticalDown_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 7, 4, rook);

        var canMove = rook.CanMove(7, 4, 0, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveDiagonally_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, rook);

        var canMove = rook.CanMove(4, 4, 6, 6, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Rook_MoveHorizontal_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 0, rook);
        TestBoardHelper.PlacePiece(board, 4, 3, blockingPiece);

        var canMove = rook.CanMove(4, 0, 4, 7, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Rook_MoveVertical_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 4, rook);
        TestBoardHelper.PlacePiece(board, 3, 4, blockingPiece);

        var canMove = rook.CanMove(0, 4, 7, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Rook_CaptureOpponentPiece_Horizontal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 0, rook);
        TestBoardHelper.PlacePiece(board, 4, 5, enemyPiece);

        var canMove = rook.CanMove(4, 0, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_CaptureOpponentPiece_Vertical_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 4, rook);
        TestBoardHelper.PlacePiece(board, 5, 4, enemyPiece);

        var canMove = rook.CanMove(0, 4, 5, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveToSameSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, rook);

        var canMove = rook.CanMove(4, 4, 4, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Rook_MoveOneSquareHorizontal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, rook);

        var canMove = rook.CanMove(4, 4, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Rook_MoveOneSquareVertical_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, rook);

        var canMove = rook.CanMove(4, 4, 5, 4, board);

        Assert.True(canMove);
    }

    [Theory]
    [InlineData(4, 4, 5, 5)]
    [InlineData(4, 4, 3, 3)]
    [InlineData(4, 4, 5, 3)]
    [InlineData(4, 4, 6, 2)]
    public void Rook_DiagonalMoves_AreIllegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, rook);

        var canMove = rook.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Rook_MoveToAdjacentSquare_WithBlockingPieceBeyond_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var rook = new Rook(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 4, 0, rook);
        TestBoardHelper.PlacePiece(board, 4, 3, blockingPiece);

        var canMove = rook.CanMove(4, 0, 4, 2, board);

        Assert.True(canMove);
    }
}
