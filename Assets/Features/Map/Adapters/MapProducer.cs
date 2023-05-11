using System;
using System.Linq;
using Features.Map.Entity;
using Features.Sector.Handler;
using Zenject;
using Random = System.Random;

namespace Features.Map.Adapters
{
    public enum CardType
    {
        None,
        Treasure,
        Coin,
        Distance,
        Energy
    }

    public class MapProducer
    {
        private readonly SignalBus _signalBus;
        private readonly IMapRepository _repository;

        public MapProducer(SignalBus signalBus, IMapRepository repository)
        {
            _signalBus = signalBus;
            _repository = repository;
        }

        public Entity.Map Generate(int rows, int columns, int countDistanceCard, int countCoinCard, int energyCard)
        {
            var map = _repository.FindCurrent();
            var deck = CreateDeck(rows * columns, countDistanceCard, countCoinCard, energyCard);
            var idx = 0;
            for (var x = 0; x < rows; x++)
            {
                for (var z = 0; z < columns; z++)
                    _signalBus.Fire(new CreateSectorCommand(x, z, deck[idx++].ToString()));
            }

            map.Activate();

            return map;
        }

        private static CardType[] CreateDeck(int countAll, int countDistanceCard, int coinCard, int energyCard)
        {
            if (countAll < countDistanceCard + coinCard + energyCard + 1)
                throw new ArgumentException("The number of cards must be greater for these parameters.");

            var deck = new CardType[countAll];
            deck[0] = CardType.Treasure;
            for (var i = 1; i <= countDistanceCard; i++) deck[i] = CardType.Distance;
            for (var i = 1; i <= coinCard; i++) deck[i] = CardType.Coin;
            for (var i = 1; i <= energyCard; i++) deck[i] = CardType.Energy;

            var rnd = new Random();
            return deck.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}