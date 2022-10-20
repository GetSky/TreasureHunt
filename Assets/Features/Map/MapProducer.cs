using System;
using System.Linq;
using Features.Map.Repository;
using Features.Sector.Handler;
using Zenject;
using CardType = Features.Sector.Card.CardType;
using Random = System.Random;

namespace Features.Map
{
    public class MapProducer
    {
        private readonly SignalBus _signalBus;
        private readonly IMapRepository _repository;

        public MapProducer(SignalBus signalBus, IMapRepository repository)
        {
            _signalBus = signalBus;
            _repository = repository;
        }

        public Map Generate(int rows, int columns, int countDistanceCard)
        {
            var map = _repository.FindCurrent();
            var deck = CreateDeck(rows * columns, countDistanceCard);
            var idx = 0;
            for (var x = 0; x < rows; x++)
            {
                for (var z = 0; z < columns; z++)
                    _signalBus.Fire(new CreateSectorCommand(x, z, deck[idx++].ToString()));
            }

            map.Activate();

            return map;
        }

        private static CardType[] CreateDeck(int countAll, int countDistanceCard)
        {
            if (countAll < countDistanceCard + 1)
                throw new ArgumentException("The number of cards must be greater for these parameters.");

            var deck = new CardType[countAll];
            deck[0] = CardType.Treasure;
            for (var i = 1; i <= countDistanceCard; i++) deck[i] = CardType.Distance;

            var rnd = new Random();
            return deck.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}