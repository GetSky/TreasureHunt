﻿using Core;

namespace Features.Camera.Commands
{
    public class LookAtCommand : ICommand
    {
        public float X { get; }
        public float Y { get; }
        public bool Immediately { get; }

        public LookAtCommand(float x, float y, bool immediately)
        {
            X = x;
            Y = y;
            Immediately = immediately;
        }
    }
}