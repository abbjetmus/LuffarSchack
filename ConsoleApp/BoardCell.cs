using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class BoardCell
    {
        public int Position { get; set; }
        public bool IsTaken { get; set; }
        public Player Player { get; set; }
        public BoardCell(int position)
        {
            Position = position;
        }
    }
}
