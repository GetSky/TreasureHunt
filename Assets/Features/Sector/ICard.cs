﻿namespace Features.Sector
{
    public enum CardType
    {
        None,
        Treasure,
        Distance
    }

    public interface ICard
    {
        public CardType Type();
        public void UpdateDistanceToTreasure(int distance);
        public int Value();
    }
}