namespace Features.Sector.Domain.Effects
{
    class NoneEffect : IEffect
    {
        public IDomainEvent Call(Sector openSector, Sector treasureSector) => null;
    }
}