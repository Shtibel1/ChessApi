using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class BishopTests
{
    [Fact]
    public void Bishop_MoveDiagonalUpRight_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, bishop);

        var canMove = bishop.CanMove(0, 0, 7, 7, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveDiagonalUpLeft_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 7, bishop);

        var canMove = bishop.CanMove(0, 7, 7, 0, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveDiagonalDownRight_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 7, 0, bishop);

        var canMove = bishop.CanMove(7, 0, 0, 7, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveDiagonalDownLeft_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 7, 7, bishop);

        var canMove = bishop.CanMove(7, 7, 0, 0, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveOneSquareDiagonal_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, bishop);

        var canMove = bishop.CanMove(4, 4, 5, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveHorizontally_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, bishop);

        var canMove = bishop.CanMove(4, 4, 4, 7, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Bishop_MoveVertically_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, bishop);

        var canMove = bishop.CanMove(4, 4, 7, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Bishop_MoveDiagonal_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 0, bishop);
        TestBoardHelper.PlacePiece(board, 3, 3, blockingPiece);

        var canMove = bishop.CanMove(0, 0, 7, 7, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Bishop_CaptureOpponentPiece_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 0, bishop);
        TestBoardHelper.PlacePiece(board, 5, 5, enemyPiece);

        var canMove = bishop.CanMove(0, 0, 5, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_CaptureOwnPiece_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        var friendlyPiece = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 0, 0, bishop);
        TestBoardHelper.PlacePiece(board, 5, 5, friendlyPiece);

        var canMove = bishop.CanMove(0, 0, 5, 5, board);

        Assert.False(canMove);
    }

    [Fact]
    public void Bishop_MoveToAdjacentDiagonal_WithBlockingPieceBeyond_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 0, 0, bishop);
        TestBoardHelper.PlacePiece(board, 3, 3, blockingPiece);

        var canMove = bishop.CanMove(0, 0, 2, 2, board);

        Assert.True(canMove);
    }

    [Fact]
    public void Bishop_MoveToSameSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 4, 4, bishop);

        var canMove = bishop.CanMove(4, 4, 4, 4, board);

        Assert.False(canMove);
    }

    [Theory]
    [InlineData(4, 4, 5, 6)] // L-shape like knight
    [InlineData(4, 4, 6, 5)] // L-shape
    [InlineData(4, 4, 6, 7)] // Not on diagonal
    public void Bishop_NonDiagonalMoves_AreIllegal(int startRow, int startCol, int endRow, int endCol)
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var bishop = new Bishop(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, startRow, startCol, bishop);

        var canMove = bishop.CanMove(startRow, startCol, endRow, endCol, board);

        Assert.False(canMove);
    }
}
