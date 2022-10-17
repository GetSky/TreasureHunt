using System;
using System.Linq;
using Features.Map.Repository;
using CardType = Features.Sector.CardType;
using Object = UnityEngine.Object;
using Random = System.Random;
using Vector2 = System.Numerics.Vector2;

namespace Features.Map
{
    public class MapProducer
    {
        private readonly IMapRepository _mapRepo;
        private readonly Sector.Factory _sectorFactory;

        public MapProducer(IMapRepository mapRepo, Sector.Factory sectorFactory)
        {
            _mapRepo = mapRepo;
            _sectorFactory = sectorFactory;
        }

        public Map Generate(int rows, int columns, int countDistanceCard)
        {
            var map = _mapRepo.FindCurrent();
            var deck = CreateDeck(rows * columns, countDistanceCard);
            var idx = 0;
            for (var x = 0; x < rows; x++)
            {
                for (var z = 0; z < columns; z++) CreateSector(x, z, deck[idx++]);
            }

            map.Activate();

            return map;
        }

        private void CreateSector(int x, int z, CardType type)
        {
            _sectorFactory.Create(new Vector2(x, z), type);
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