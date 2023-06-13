using Battleship.Enums;
namespace Battleship.Interfaces
{
    public interface IBoard
    {
        Result StartShot(int row, int col);
        bool AreAllShipsSunk();
        void Display();
        bool CanPlaceShip(IShip ship, int row, int col, int direction);
        void PlaceShip(IShip ship, int row, int col, int direction);
    }
}
