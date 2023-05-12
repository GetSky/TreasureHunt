using Core;
using Features.OldSector.Event;

namespace Features.OldSector.Commands
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