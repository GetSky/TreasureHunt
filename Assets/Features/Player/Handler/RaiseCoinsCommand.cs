﻿using Core;

namespace Features.Player.Handler
{
    public class RaiseCoinsCommand : ICommand
    {
        public int Count { get; }

        public RaiseCoinsCommand(int count)
        {
            Count = count;
        }
    }
}