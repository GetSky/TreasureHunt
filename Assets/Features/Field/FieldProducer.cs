using System;
using Features.Sector;
using Object = UnityEngine.Object;
using Random = System.Random;
using Vector2 = System.Numerics.Vector2;

namespace Features.Field
{
    public class FieldProducer
    {
        private readonly Factory _groundFactory;
        private readonly Object _groundPrefab;

        public FieldProducer(Factory groundFactory, Object groundPrefab)
        {
            _groundFactory = groundFactory;
            _groundPrefab = groundPrefab;
        }

        public void Generate(int rows, int columns)
        {
            var (tpX, tpZ) = GenerateTreasurePosition(rows, columns);

            for (var x = 0; x <= rows; x++)
            {
                for (var z = 0; z <= columns; z++)
                {
                    CreateGround(tpX, x, tpZ, z);
                }
            }
        }

        private void CreateGround(int tpX, int x, int tpZ, int z)
        {
            var isTreasure = Math.Abs(tpX - x) < 0.1 && Math.Abs(tpZ - z) < 0.1;
            _groundFactory.Create(new Vector2(x, z), isTreasure, _groundPrefab);
        }

        private static (int, int) GenerateTreasurePosition(int rows, int columns)
        {
            var rand = new Random();
            return (rand.Next(0, rows), rand.Next(0, columns));
        }
    }
}