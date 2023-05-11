using Core;
using Features.Player.Adapters;
using Features.Player.Commands;
using Features.Player.Entity;
using Features.Player.UseCases;
using Features.Sector.Event;
using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Installer : Installer<GameObject, Installer>
    {
        private readonly GameObject _coinsCounterPrefab;

        public Installer(GameObject coinsCounterPrefab)
        {
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().Lazy();
            Container.Bind<IInteractor<RaiseCoinsCommand>>().To<RaiseCoinsInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<RequestCountCoinsCommand>>().To<RequestCoinsInteractor>().AsSingle().Lazy();

            Container
                .Bind(typeof(ICoinPresenterBoundary), typeof(ICoinPresenter))
                .To<CoinPresenter>()
                .AsSingle()
                .Lazy();

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