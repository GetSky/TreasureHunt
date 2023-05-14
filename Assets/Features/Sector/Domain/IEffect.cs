namespace Features.Sector.Domain
{
    public interface IEffect
    {
        public IDomainEvent Call(Sector openSector, Sector treasureSector);
    }
}