using System;
using System.Linq;
using Features.Map.Entity;
using Features.Sector;
using Features.Sector.UseCases.CreateSector;
using Random = System.Random;

namespace Features.Map.Adapters
{
    public enum CardType
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

    public class MapProducer
    {
        private readonly Gateway _sectorGateway;
        private readonly IMapRepository _repository;

        public MapProducer(Gateway sectorGateway, IMapRepository repository)
        {
            _sectorGateway = sectorGateway;
            _repository = repository;
        }

        public Entity.Map Generate(
            int rows,
            int columns,
            int countDistanceCard,
            int countCoinCard,
            int energyCard,
            int directionCard,
            int randomOpenCard,
            int showLocationCard,
            int bombCard
        )
        {
            var map = _repository.FindCurrent();
            var deck = CreateDeck(
                rows * columns,
                countDistanceCard,
                countCoinCard,
                energyCard,
                directionCard,
                randomOpenCard,
                showLocationCard,
                bombCard
            );
            var idx = 0;
            for (var x = 0; x < rows; x++)
            {
                for (var z = 0; z < columns; z++)
                    _sectorGateway.Schedule(new CreateSectorCommand(x, z, deck[idx++].ToString()));
            }

            map.Activate();

            return map;
        }

        private static CardType[] CreateDeck(
            int countAll,
            int countDistanceCard,
            int coinCard,
            int energyCard,
            int directionCard,
            int randomOpenCard,
            int showLocationCard,
            int bombCard
        )
        {
            if (countAll < countDistanceCard + coinCard + energyCard + 1)
                throw new ArgumentException("The number of cards must be greater for these parameters.");

            var deck = new CardType[countAll];
            deck[0] = CardType.Treasure;
            for (var i = 1; i <= countDistanceCard; i++) deck[i] = CardType.Distance;
            for (var i = 1; i <= coinCard; i++) deck[i] = CardType.Coin;
            for (var i = 1; i <= energyCard; i++) deck[i] = CardType.Energy;
            for (var i = 1; i <= directionCard; i++) deck[i] = CardType.Direction;
            for (var i = 1; i <= randomOpenCard; i++) deck[i] = CardType.RandomOpen;
            for (var i = 1; i <= showLocationCard; i++) deck[i] = CardType.CardsLocation;
            for (var i = 1; i <= bombCard; i++) deck[i] = CardType.Bomb;

            var rnd = new Random();
            return deck.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}