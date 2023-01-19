using Features.Player.Handler;
using Features.Player.Repository;
using Features.Sector.Event;
using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class PlayerInstaller : Installer<GameObject, PlayerInstaller>
    {
        private readonly GameObject _coinsCounterPrefab;

        public PlayerInstaller(GameObject coinsCounterPrefab)
        {
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().Lazy();
            Container.Bind<IRaiseCoinsHandler>().To<RaiseCoinsHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IPlayerContext), typeof(IPlayerRepository))
                .To<PlayerPrefsRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureFound>().ToMethod<SectorConnector>(c => c.TreasureFind).FromResolve();
            Container.BindSignal<CoinFound>().ToMethod<SectorConnector>(c => c.CoinFind).FromResolve();

            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_coinsCounterPrefab).Lazy();
        }
    }
}