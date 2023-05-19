﻿using Features.Sector.Domain.Effects;

namespace Features.Sector.Domain
{
    public enum EffectType
    {
        None,
        Treasure,
        Coin,
        Distance,
        Direction,
        Energy,
        RandomOpen,
        CardsLocation,
        Bomb
    }

    public interface IEffect
    {
        public IEventDomainEvent Call(Sector openSector, Sector treasureSector);
    }
}