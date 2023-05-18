using System;
using System.Globalization;
using Features.Sector.Adapters;
using Features.Sector.Domain;
using Features.Sector.Domain.Effects;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Features.Sector
{
    public class SectorFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public SectorFactory(DiContainer container, GameObject prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public Domain.Sector Create(float x, float z, EffectType type)
        {
            var subContainer = _container.CreateSubContainer();
            var id = x.ToString(CultureInfo.CurrentCulture) + z.ToString(CultureInfo.CurrentCulture);

            IEffect effect = type switch
            {
                EffectType.None => new EmptyEffect(),
                EffectType.Treasure => new TreasureEffect(1),
                EffectType.Coin => new CoinEffect(10),
                EffectType.Distance => new DisplayDistanceEffect(5),
                EffectType.Energy => new EnergyEffect(2),
                EffectType.Direction => new DisplayDirectionEffect(1),
                EffectType.RandomOpen => new RandomSectorsEffect(1),
                EffectType.CardsLocation => new DisplayEffectLocationEffect(1),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            var entity = new Domain.Sector(id, new Vector2(x, z), effect);

            subContainer.Bind<Domain.Sector>().FromInstance(entity).AsSingle();

            CreateView(subContainer, x, z);

            return entity;
        }

        private void CreateView(DiContainer container, float x, float z)
        {
            container.Bind<SectorPresenter>().AsSingle();
            var gameObject = container.InstantiatePrefab(_prefab);
            gameObject.transform.position = new Vector3(x, 0.0f, z);
        }
    }
}