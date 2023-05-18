namespace Features.Sector.Domain.Effects.Events
{
    public class HintEffectLocationDiscovered : IEventDomainEvent
    {
        public float X { get; }
        public float Z { get; }
        public EffectState EffectState { get; }

        public HintEffectLocationDiscovered(float x, float z, EffectState state)
        {
            X = x;
            Z = z;
            EffectState = state;
        }
    }
}