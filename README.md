# Chess REST API

[![CI](https://github.com/shtikitin/ChessApi/actions/workflows/ci.yml/badge.svg)](https://github.com/shtikitin/ChessApi/actions/workflows/ci.yml)

A RESTful chess API built with ASP.NET Core 8.0 that validates and executes chess moves according to standard chess rules.

## Architecture

The project follows a layered architecture:

```
ChessApi.sln
├── ChessApi/           # ASP.NET Core Web API layer
│   └── Controllers/
│       └── ChessController.cs
└── BLL/                # Business Logic Layer
    └── Chess/
        ├── ChessService.cs      # Game state and move orchestration
        ├── ChessHelper.cs       # Board utilities and king safety checks
        └── Players/             # Piece implementations
            ├── IPlayer.cs       # Common interface for all pieces
            ├── Pawn.cs
            ├── Rook.cs
            ├── Knight.cs
            ├── Bishop.cs
            ├── Queen.cs
            └── King.cs
```

### Key Design

- **Piece polymorphism**: All pieces implement `IPlayer`, which defines `CanMove(x, y, i, j, board)` for movement validation
- **Move validation**: Each piece class encodes its own movement rules, including blocking piece detection
- **King safety**: `ChessHelper.IsKingNotThreatened()` ensures moves don't leave the player's king in check

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/chess` | Returns the current board state as a 2D array of squares |
| `POST` | `/api/chess/move` | Executes a move if valid; returns 200 OK or 400 Bad Request |

### Move Request Body

```json
{
  "x": 1,    // source row (0-7)
  "y": 4,    // source column (0-7)
  "i": 3,    // destination row (0-7)
  "j": 4     // destination column (0-7)
}
```

Board coordinates use a 0-indexed 8×8 grid where row 0 is White's back rank and row 7 is Black's back rank.

## Running Locally

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Build and Run

```bash
# Restore and build
dotnet build

# Run the API (default: http://localhost:5104)
dotnet run --project ChessApi
```

### Run Tests

```bash
dotnet test
```

The test suite (`BLL.Tests`) includes 92 xUnit tests covering:
- Movement validation for all piece types
- Blocking and capture rules
- Board edge cases
- Pawn special moves (double-step, diagonal capture)
- Knight jumping behavior

## License

This project is provided as a portfolio demonstration.
