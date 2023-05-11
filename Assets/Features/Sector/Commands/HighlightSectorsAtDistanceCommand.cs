﻿using Core;
using Features.Sector.Event;

namespace Features.Sector.Commands
{
    public class HighlightSectorsAtDistanceCommand : IDomainEvent, ICommand
    {
        public string Id { get; }
        public int Distance { get; }

        public HighlightSectorsAtDistanceCommand(string id, int distance)
        {
            Id = id;
            Distance = distance;
        }
    }
}