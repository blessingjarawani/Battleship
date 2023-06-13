using Battleship.Enums;
using Battleship.Interfaces;
namespace Battleship.Models
{
    public class Board : IBoard
    {
        private readonly char[,] _grid;
        private  readonly List<IShip> _ships;

        public Board()
        {
            _grid = new char[10, 10];
            _ships = new List<IShip>();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _grid[i, j] = 'O';
                }
            }
        }


        public bool AreAllShipsSunk()
        {
            return _ships.Any(t => !t.IsSunk(_grid));

        }
        public void Display()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1,2} ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(_grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool CanPlaceShip(IShip ship, int row, int col, int direction)
        {
            if (direction == 0 && col + ship.Size <= 10)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    if (_grid[row, col + i] != 'O')
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (direction == 1 && row + ship.Size <= 10)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    if (_grid[row + i, col] != 'O')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void PlaceShip(IShip ship, int row, int col, int direction)
        {
            if (direction == 0)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    _grid[row, col + i] = 'S';
                }
            }
            else if (direction == 1)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    _grid[row + i, col] = 'S';
                }
            }
            _ships.Add(ship);
        }

        public Result StartShot(int row, int col)
        {
            if (_grid[row, col] == 'O')
            {
                _grid[row, col] = 'M';
                return Result.Misses;
            }

            if (_grid[row, col] == 'S')
            {
                _grid[row, col] = 'X';
                return Result.Hits;
            }

            return Result.Invalid;
        }


    }
}