namespace Features.Sector.Domain.Events
{
    public class HintDistanceDiscovered : IDomainEvent
    {
        public string OpenSectorId { get; }
        public int Distance { get; }

        public HintDistanceDiscovered(string openSectorId, int distance)
        {
            OpenSectorId = openSectorId;
            Distance = distance;
        }
    }
}