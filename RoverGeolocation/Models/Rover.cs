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
        public char CardinalOrientation { get; set; }

        public Rover() {
            PositionX = 0;
            PositionY = 0;
            CardinalOrientation = 'n';
        }

        

        public void Move(char[] commands)
        {
            for (int i =0;i<commands.Length;i++) {
                if (commands[i]==(char)Enums.CommandsAccepted.Forward) {
                    this.PositionY++;
                    this.CardinalOrientation = (char)Enums.CardinalOrientation.North;
                }
                if (commands[i]==(char)Enums.CommandsAccepted.Backward) {
                    this.PositionY--;
                    this.CardinalOrientation = (char)Enums.CardinalOrientation.South;
                }
            }
        }

    }
}
