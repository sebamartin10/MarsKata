using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Utils
{
    public static class Enums
    {
        public enum CardinalOrientation {
            North='n',
            South='s',
            East='e',
            West='w'
        };
        public enum CommandsAccepted {
            Forward = 'f',
            Backward = 'b',
            Left = 'l',
            Right = 'r'
        }
    }
}
