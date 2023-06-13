using Battleship.Interfaces;
using Battleship.Models;
using System;
using System.Collections.Generic;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IGame game = new Game();
            game.Play();
        }
    }

}