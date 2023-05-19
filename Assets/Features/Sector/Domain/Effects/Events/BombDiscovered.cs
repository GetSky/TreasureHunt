namespace Features.Sector.Domain.Effects.Events
{
    public class BombDiscovered : IEventDomainEvent
    {
        public EffectState EffectState { get; }
        public float X { get; }
        public float Z { get; }

        public BombDiscovered(float x, float z, EffectState state)
        {
            X = x;
            Z = z;
            EffectState = state;
        }
    }
}