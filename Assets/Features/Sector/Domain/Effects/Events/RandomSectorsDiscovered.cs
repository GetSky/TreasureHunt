namespace Features.Sector.Domain.Effects.Events
{
    public class RandomSectorsDiscovered : IEventDomainEvent
    {
        public float X { get; }
        public float Z { get; }
        public EffectState EffectState { get; }

        public RandomSectorsDiscovered(float x, float z, EffectState effectState)
        {
            X = x;
            Z = z;
            EffectState = effectState;
        }
    }
}