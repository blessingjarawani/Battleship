using Battleship.Enums;
using Battleship.Interfaces;
namespace Battleship.Models
{
    public class Game : IGame
    {
        private readonly IBoard _board;
        private List<IShip> _ships;
        public Game()
        {
            _board = new Board();
            _ships = new List<IShip>
            {
                new BattleShip(size:5),
                new Destroyer(size:4),
                new Destroyer(size:4)
            };

            PlaceShips();
        }

        private void PlaceShips()
        {
            Random random = new Random();

            foreach (var ship in _ships)
            {
                bool placed = false;
                while (!placed)
                {
                    int row = random.Next(10);
                    int col = random.Next(10);
                    int direction = random.Next(2);

                    if (_board.CanPlaceShip(ship, row, col, direction))
                    {
                        _board.PlaceShip(ship, row, col, direction);
                        placed = true;
                    }
                }
            }
        }
        public void Play()
        {
            bool gameOver = false; 
            do
            {
                 Console.Clear();
                _board.Display();

                Console.WriteLine("Enter coordinates (for example, A5): ");
               
                var input = Console.ReadLine().ToUpper();

                if (input.Length != 2 || !Char.IsLetter(input[0]) || !Char.IsDigit(input[1]))
                {
                    Console.WriteLine("Invalid input! Enter coordinates in the form A1.");
                    Console.ReadLine();
                    continue;
                }

                int col = input[0] - 'A';
                int row = input[1] - '1';

                if (col < 0 || col >= 10 || row < 0 || row >= 10)
                {
                    Console.WriteLine("Invalid coordinates! Enter coordinates within the grid.");
                    Console.ReadLine();
                    continue;
                }

                var result = _board.StartShot(row, col);

                if (result == Result.Invalid)
                {
                    Console.WriteLine("Square Already Targeted.");
                    Console.ReadLine();
                    continue;
                }
                else if (result == Result.Hits)
                {
                    Console.WriteLine("Hits");
                    if (_board.AreAllShipsSunk())
                    {
                        gameOver = true;
                    }
                }
                else if (result == Result.Misses)
                {
                    Console.WriteLine("Misses!");
                }

             
            } while (!gameOver);

            Console.Clear();
            _board.Display();
            Console.WriteLine($"Congratulations!");
            Console.ReadLine();
        }
    }
}
