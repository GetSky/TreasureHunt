namespace Features.Sector.UseCases.HighlightSectorsAtDistance
{
    public class HighlightSectorsAtDistanceCommand : ICommand
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