using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Player
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public Player(string name, string sign)
        {
            Name = name;
            Sign = sign;    
        }
    }
}
