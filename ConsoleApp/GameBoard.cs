using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class GameBoard
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        BoardCell[] Cells = new BoardCell[9];
        public bool Player1Turn { get; set; }
        public GameBoard(Player p1, Player p2)
        {
            Player1 = p1; 
            Player2 = p2;
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new BoardCell(i);
            }
            Player1Turn = true; 
        }

        public void Start()
        {
            while(true)
            {
                DisplayBoard();

                if (Player1Turn)
                {
                    GetAnswer(Player1);
                    Player1Turn = false;
                }
                else
                {
                    GetAnswer(Player2);
                    Player1Turn = true;
                }

                if(CheckForWinner())
                {
                    DisplayBoard();

                    Console.WriteLine($"{(Player1Turn ? Player2.Name : Player1.Name)} är vinnare!");
                    break;
                }
                if(CheckForDraw())
                {
                    DisplayBoard();

                    Console.WriteLine("Det blev oavgjort!");
                    break;
                }
            }
        }

        public void GetAnswer(Player player)
        {
 
            bool valid = false;

            do
            {
                Console.WriteLine($"{player.Name} tur att välja? För att avsluta spelet ange tangenten Q.");
                var answer = Console.ReadLine();
                int position;

                if (int.TryParse(answer, out position))
                {
                    if (Cells[position - 1].Player == null)
                    {
                        Cells[position - 1].Player = player;
                        Cells[position - 1].IsTaken = true;
                        valid = true;
                    }
                }
                else
                {
                    if (answer == "q" || answer == "Q")
                    {
                        valid = true;
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"Felaktigt val!");
                    }
                }

            } while (!valid);
 

        }


        public void DisplayBoard()
        {
            Console.WriteLine($"-------");
            Console.WriteLine($"|{(Cells[0].Player != null ? Cells[0].Player.Sign : "1")}|{(Cells[1].Player != null ? Cells[1].Player.Sign : "2")}|{(Cells[2].Player != null ? Cells[2].Player.Sign : "3")}|");
            Console.WriteLine($"-------");
            Console.WriteLine($"|{(Cells[3].Player != null ? Cells[3].Player.Sign : "4")}|{(Cells[4].Player != null ? Cells[4].Player.Sign : "5")}|{(Cells[5].Player != null ? Cells[5].Player.Sign : "6")}|");
            Console.WriteLine($"-------");
            Console.WriteLine($"|{(Cells[6].Player != null ? Cells[6].Player.Sign : "7")}|{(Cells[7].Player != null ? Cells[7].Player.Sign : "8")}|{(Cells[8].Player != null ? Cells[8].Player.Sign : "9")}|");
            Console.WriteLine($"-------");
        }

        public bool CheckForWinner() {
            if(Cells[0].IsTaken && Cells[1].IsTaken && Cells[2].IsTaken)
            {
               return true;
            } 
            else if(Cells[3].IsTaken && Cells[4].IsTaken && Cells[5].IsTaken)
            {
                return true;
            }
            else if (Cells[6].IsTaken && Cells[7].IsTaken && Cells[8].IsTaken)
            {
                return true;
            }
            else if (Cells[0].IsTaken && Cells[3].IsTaken && Cells[6].IsTaken)
            {
                return true;
            }
            else if (Cells[1].IsTaken && Cells[4].IsTaken && Cells[7].IsTaken)
            {
                return true;
            }
            else if (Cells[2].IsTaken && Cells[5].IsTaken && Cells[8].IsTaken)
            {
                return true;
            }
            else if (Cells[0].IsTaken && Cells[4].IsTaken && Cells[8].IsTaken)
            {
                return true;
            }
            else if (Cells[2].IsTaken && Cells[4].IsTaken && Cells[6].IsTaken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForDraw()
        {
            var isDraw = true;
            for (int i = 0; i < Cells.Length; i++)
            {
                if (!Cells[i].IsTaken)
                {
                    isDraw = false;
                }
            }
            return isDraw;
        }

    }
}
