using BLL;
using BLL.Enums;
using BLL.Players;
using Xunit;

namespace BLL.Tests;

public class PawnTests
{
    [Fact]
    public void WhitePawn_SingleStepForward_FromStartingRow_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 1, 4, pawn);

        var canMove = pawn.CanMove(1, 4, 2, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void WhitePawn_DoubleStepForward_FromStartingRow_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 1, 4, pawn);

        var canMove = pawn.CanMove(1, 4, 3, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void WhitePawn_DoubleStep_FromNonStartingRow_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 2, 4, pawn);

        var canMove = pawn.CanMove(2, 4, 4, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_SingleStepForward_Blocked_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 1, 4, pawn);
        TestBoardHelper.PlacePiece(board, 2, 4, blockingPiece);

        var canMove = pawn.CanMove(1, 4, 2, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_DoubleStepForward_BlockedOnFirstSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 1, 4, pawn);
        TestBoardHelper.PlacePiece(board, 2, 4, blockingPiece);

        var canMove = pawn.CanMove(1, 4, 3, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_DoubleStepForward_BlockedOnSecondSquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var blockingPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 1, 4, pawn);
        TestBoardHelper.PlacePiece(board, 3, 4, blockingPiece);

        var canMove = pawn.CanMove(1, 4, 3, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_DiagonalCapture_OpponentPiece_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);
        TestBoardHelper.PlacePiece(board, 4, 5, enemyPiece);

        var canMove = pawn.CanMove(3, 4, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void WhitePawn_DiagonalCapture_LeftSide_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var enemyPiece = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);
        TestBoardHelper.PlacePiece(board, 4, 3, enemyPiece);

        var canMove = pawn.CanMove(3, 4, 4, 3, board);

        Assert.True(canMove);
    }

    [Fact]
    public void WhitePawn_DiagonalMove_EmptySquare_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);

        var canMove = pawn.CanMove(3, 4, 4, 5, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_DiagonalCapture_OwnPiece_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        var friendlyPiece = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);
        TestBoardHelper.PlacePiece(board, 4, 5, friendlyPiece);

        var canMove = pawn.CanMove(3, 4, 4, 5, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_MoveBackward_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);

        var canMove = pawn.CanMove(3, 4, 2, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void WhitePawn_MoveSideways_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 3, 4, pawn);

        var canMove = pawn.CanMove(3, 4, 3, 5, board);

        Assert.False(canMove);
    }

    [Fact]
    public void BlackPawn_SingleStepForward_FromStartingRow_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 6, 4, pawn);

        var canMove = pawn.CanMove(6, 4, 5, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void BlackPawn_DoubleStepForward_FromStartingRow_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 6, 4, pawn);

        var canMove = pawn.CanMove(6, 4, 4, 4, board);

        Assert.True(canMove);
    }

    [Fact]
    public void BlackPawn_DoubleStep_FromNonStartingRow_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 5, 4, pawn);

        var canMove = pawn.CanMove(5, 4, 3, 4, board);

        Assert.False(canMove);
    }

    [Fact]
    public void BlackPawn_DiagonalCapture_OpponentPiece_IsLegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.Black);
        var enemyPiece = new Pawn(PlayerColor.White);
        TestBoardHelper.PlacePiece(board, 5, 4, pawn);
        TestBoardHelper.PlacePiece(board, 4, 5, enemyPiece);

        var canMove = pawn.CanMove(5, 4, 4, 5, board);

        Assert.True(canMove);
    }

    [Fact]
    public void BlackPawn_MoveBackward_IsIllegal()
    {
        var board = TestBoardHelper.CreateEmptyBoard();
        var pawn = new Pawn(PlayerColor.Black);
        TestBoardHelper.PlacePiece(board, 5, 4, pawn);

        var canMove = pawn.CanMove(5, 4, 6, 4, board);

        Assert.False(canMove);
    }
}
