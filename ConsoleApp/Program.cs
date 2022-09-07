using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ange namnet på spelare 1");
            var player1Name = Console.ReadLine();

            Console.WriteLine("Ange namnet på spelare 2");
            var player2Name = Console.ReadLine();

            Player player1 = new Player(player1Name, "X");
            Player player2 = new Player(player2Name, "O");

            var board = new GameBoard(player1, player2);
            board.Start();
        }
    }
}
