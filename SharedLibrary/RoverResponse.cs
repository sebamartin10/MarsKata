using System;

namespace SharedLibrary
{
    public class RoverResponse <T>
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = String.Empty;
        public T Rover { get; set; }
    }
}
