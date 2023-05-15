namespace Features.Sector.Domain
{
    public enum EffectType
    {
        None,
        Treasure,
        Coin,
        Distance,
        Energy,
    }
    public interface IEffect
    {
        public IDomainEvent Call(Sector openSector, Sector treasureSector);
    }
}