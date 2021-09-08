using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Models
{
    public class Vehicle
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string CardinalOrientation { get; set; }
        public List<char> AcceptedCommands { get; set; }
    }
}
