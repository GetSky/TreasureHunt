namespace Features.Sector.Domain.Effects.Events
{
    public class EnergyDiscovered : IEventDomainEvent
    {
        public EffectState EffectState { get; }
        public float X { get; }
        public float Y { get; }

        public EnergyDiscovered(float x, float y, EffectState state)
        {
            X = x;
            Y = y;
            EffectState = state;
        }
    }
}