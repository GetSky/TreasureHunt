﻿namespace Features.Sector.Event
{
    public class TreasureFound : IDomainEvent
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public TreasureFound(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}