namespace Features.Sector.Domain.Effects
{
    public interface IEventDomainEvent : IDomainEvent
    {
        public EffectState EffectState { get; }
    }
}