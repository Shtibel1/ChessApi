using BLL.Chess.Players;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPlayer
    {
        PlayerColor Color { get; set; }
        string? Img { get; set; }
        PlayerType Type { get; set; }
        bool CanMove(int x, int y, int i, int j, Square[,] board);
    }
}
