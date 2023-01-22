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
                CardType.Coin => new CoinCard(10),
                CardType.Distance => new DistanceCard(),
                CardType.Energy => new EnergyCard(1),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}