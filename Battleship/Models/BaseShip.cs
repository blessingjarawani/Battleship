using Battleship.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public abstract class BaseShip : IShip
    {
        public int Size { get; }
        protected BaseShip(int size)
        {
            Size = size;
        }
       
        public bool IsSunk(char[,] grid)
        {
            int count = 0;
            foreach (char cell in grid)
            {
                if (cell == 'X')
                {
                    count++;
                }
            }
            return count == Size;
        }
    }
}
