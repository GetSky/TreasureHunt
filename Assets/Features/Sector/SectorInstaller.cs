using Features.Sector.Card;
using Features.Sector.Event;
using Features.Sector.Handler;
using Features.Sector.Repository;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Features.Sector
{
    public class SectorInstaller : Installer<SectorInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Vector2, CardType, Object, Sector, Factory>().FromFactory<SectorFactory>();
            Container.BindFactory<CardType, ICard, Features.Sector.Card.Factory>().FromFactory<CardFactory>();

            Container.Bind<ISectorOpenHandler>().To<SectorOpenHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(ISectorRepository), typeof(ISectorFlasher))
                .To<MemorySectorRepository>()
                .AsSingle()
                .NonLazy();

            Container.DeclareSignal<TreasureFind>();
        }
    }
}