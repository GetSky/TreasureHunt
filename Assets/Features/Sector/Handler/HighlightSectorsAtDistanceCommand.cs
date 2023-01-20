using Features.Sector.Event;

namespace Features.Sector.Handler
{
    public class HighlightSectorsAtDistanceCommand : IDomainEvent
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