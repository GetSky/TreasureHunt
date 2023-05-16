namespace Features.Sector.Domain.Effects.Events
{
    public class HintDirectionDiscovered : IEventDomainEvent
    {
        public EffectState EffectState { get; }
        public string OpenSectorId { get; }

        public HintDirectionDiscovered(string openSectorId, EffectState state)
        {
            OpenSectorId = openSectorId;
            EffectState = state;
        }
    }
}