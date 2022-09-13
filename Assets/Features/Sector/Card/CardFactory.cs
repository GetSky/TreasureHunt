using System;
using Zenject;

namespace Features.Sector.Card
{
    public class Factory : PlaceholderFactory<CardType, ICard>
    {
    }

    public class CardFactory : IFactory<CardType, ICard>
    {
        public ICard Create(CardType type)
        {
            return type switch
            {
                CardType.None => new NoneCard(),
                CardType.Treasure => new TreasureCard(),
                CardType.Distance => new DistanceCard(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}