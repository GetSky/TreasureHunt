namespace Features.Sector.UseCases.HighlightSectorsAtDirection
{
    public class HighlightSectorsAtDirectionCommand : ICommand
    {
        public string Id { get; }
        public int Angle { get; }

        public HighlightSectorsAtDirectionCommand(string id, int angle)
        {
            Id = id;
            Angle = angle;
        }
    }
}