using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Interfaces
{
    public interface IShip
    {
        
        bool IsSunk(char[,] grid);
        public int Size { get; }

    }
}
