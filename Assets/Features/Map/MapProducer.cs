using System;
using Features.Sector;
using Object = UnityEngine.Object;
using Random = System.Random;
using Vector2 = System.Numerics.Vector2;

namespace Features.Map
{
    public class MapProducer
    {
        private readonly Factory _sectorFactory;
        private readonly Object _sectorPrefab;

        public MapProducer(Factory sectorFactory, Object sectorPrefab)
        {
            _sectorFactory = sectorFactory;
            _sectorPrefab = sectorPrefab;
        }

        public void Generate(int rows, int columns)
        {
            var (tpX, tpZ) = GenerateTreasurePosition(rows, columns);

            for (var x = 0; x <= rows; x++)
            {
                for (var z = 0; z <= columns; z++)
                {
                    CreateSector(tpX, x, tpZ, z);
                }
            }
        }

        private void CreateSector(int tpX, int x, int tpZ, int z)
        {
            var isTreasure = Math.Abs(tpX - x) < 0.1 && Math.Abs(tpZ - z) < 0.1;
            _sectorFactory.Create(new Vector2(x, z), isTreasure ? CardType.Treasure : CardType.Distance, _sectorPrefab);
        }

        private static (int, int) GenerateTreasurePosition(int rows, int columns)
        {
            var rand = new Random();
            return (rand.Next(0, rows), rand.Next(0, columns));
        }
    }
}