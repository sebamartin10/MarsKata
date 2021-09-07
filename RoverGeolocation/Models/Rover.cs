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
        public List<char> AcceptedCommands { get; set; }

        public Rover() {
            PositionX = 0;
            PositionY = 0;
            CardinalOrientation = (char)Enums.CardinalOrientation.North;
            AcceptedCommands = new List<char>();
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Forward);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Backward);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Right);
            AcceptedCommands.Add((char)Enums.CommandsAccepted.Left);
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
                if (commands[i] == (char)Enums.CommandsAccepted.Left) {
                    this.PositionX--;
                    this.CardinalOrientation = (char)Enums.CardinalOrientation.East;
                }
                if (commands[i] == (char)Enums.CommandsAccepted.Right) {
                    this.PositionX++;
                    this.CardinalOrientation = (char)Enums.CardinalOrientation.West;
                }
            }
        }

        public bool CheckCommandsIntegrity(char[] commands)
        {
            for (int i=0;i<commands.Length;i++) {
                if (!this.AcceptedCommands.Contains(commands[i])) return false;
            }
            return true;
        }
    }
}
