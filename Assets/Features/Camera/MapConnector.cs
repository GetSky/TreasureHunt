﻿using Core;
using Features.Camera.Handler;
using Features.Map.Event;

namespace Features.Camera
{
    public class MapConnector
    {
        private readonly IHandler<LookAtCommand> _handler;

        public MapConnector(IHandler<LookAtCommand> handler)
        {
            _handler = handler;
        }

        public void MapReload(MapLoaded _)
        {
            _handler.Invoke(new LookAtCommand(4.5f, 4f, true));
        }
    }
}