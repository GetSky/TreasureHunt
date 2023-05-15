namespace Features.Sector.Domain.Effects
{
    public class NoneEffect : IEffect
    {
        public IDomainEvent Call(Sector openSector, Sector treasureSector) => null;
    }
}