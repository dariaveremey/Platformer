using System;

namespace Services.Location
{
    public interface ILocationService
    {
        bool IsValid { get; }
        Coords Coords { get; } //x-latitued, y - longitude 
        void Bootstrap(Action completeCallback);
    }
}