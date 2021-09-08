using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Services.Contracts
{
    public interface IValidationService
    {
        public bool CheckCommandsIntegrity(char[] commands);
    }
}
