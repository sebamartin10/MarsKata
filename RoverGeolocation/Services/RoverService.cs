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
                switch (commands[i]) {
                    case (char)Enums.CommandsAccepted.Forward:
                        rover.PositionY++;
                        rover.CardinalOrientation = Enums.CardinalOrientation.North.ToString();
                        break;

                    case (char)Enums.CommandsAccepted.Backward:
                        rover.PositionY--;
                        rover.CardinalOrientation = Enums.CardinalOrientation.South.ToString();
                        break;
                    case (char)Enums.CommandsAccepted.Left:
                        rover.PositionX--;
                        rover.CardinalOrientation = Enums.CardinalOrientation.West.ToString();
                        break;
                    case (char)Enums.CommandsAccepted.Right:
                        rover.PositionX++;
                        rover.CardinalOrientation = Enums.CardinalOrientation.East.ToString();
                        break;
                }
                
            }
        }

        public bool CheckCommandsIntegrity(char[] commands)
        {
            if (commands.Length==0) {
                return false;
            }
            for (int i = 0; i < commands.Length; i++)
            {
                if (!rover.AcceptedCommands.Contains(commands[i])) return false;
            }
            return true;
        }
    }
}
