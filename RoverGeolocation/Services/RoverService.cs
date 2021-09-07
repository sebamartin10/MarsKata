using RoverGeolocation.Models;
using RoverGeolocation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Services
{
    public class RoverService
    {
        Rover rover;

        public RoverService(Rover rover) {
            this.rover = rover;
        }
        public void Move(char[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == (char)Enums.CommandsAccepted.Forward)
                {
                    rover.PositionY++;
                    rover.CardinalOrientation = (char)Enums.CardinalOrientation.North;
                }
                if (commands[i] == (char)Enums.CommandsAccepted.Backward)
                {
                    rover.PositionY--;
                    rover.CardinalOrientation = (char)Enums.CardinalOrientation.South;
                }
                if (commands[i] == (char)Enums.CommandsAccepted.Left)
                {
                    rover.PositionX--;
                    rover.CardinalOrientation = (char)Enums.CardinalOrientation.East;
                }
                if (commands[i] == (char)Enums.CommandsAccepted.Right)
                {
                    rover.PositionX++;
                    rover.CardinalOrientation = (char)Enums.CardinalOrientation.West;
                }
            }
        }

        public bool CheckCommandsIntegrity(char[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (!rover.AcceptedCommands.Contains(commands[i])) return false;
            }
            return true;
        }
    }
}
