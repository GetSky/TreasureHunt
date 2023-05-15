namespace Features.Sector.Domain.Effects.Events
{
    public class HintDistanceDiscovered : IEventDomainEvent
    {
        public EffectState EffectState { get; }
        public string OpenSectorId { get; }

        public HintDistanceDiscovered(string openSectorId, EffectState state)
        {
            OpenSectorId = openSectorId;
            EffectState = state;
        }
    }
}