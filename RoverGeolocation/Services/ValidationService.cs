using RoverGeolocation.Models;
using RoverGeolocation.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Services
{
    public class ValidationService : IValidationService
    {
        Vehicle vehicle;
        public ValidationService(Vehicle vehicle) {
            this.vehicle = vehicle;
        }
        public bool CheckCommandsIntegrity(char[] commands)
        {
            if (commands.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < commands.Length; i++)
            {
                if (!vehicle.AcceptedCommands.Contains(commands[i])) return false;
            }
            return true;
        }
    }
}
