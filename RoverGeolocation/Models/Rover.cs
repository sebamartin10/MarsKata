using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoverGeolocation.Utils;

namespace RoverGeolocation.Models
{
    public class Rover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string CardinalOrientation { get; set; }
        public List<char> AcceptedCommands { get; set; }

        public Rover() {
            PositionX = 0;
            PositionY = 0;
            CardinalOrientation = Enums.CardinalOrientation.North.ToString();
            AcceptedCommands = new List<char>();
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Forward);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Backward);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Right);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Left);
        }

    }
}
