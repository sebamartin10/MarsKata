using System;

namespace SharedLibrary
{
    public class VehicleResponse <T>
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = String.Empty;
        public T VehicleStatus { get; set; }
    }
}
