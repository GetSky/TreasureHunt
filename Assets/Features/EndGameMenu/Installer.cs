using Core;
using Features.EndGameMenu.Adapters;
using Features.EndGameMenu.Commands;
using Features.EndGameMenu.UseCases;
using Features.Map.Event;
using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class Installer : Installer<GameObject, Installer>
    {
        private readonly GameObject _endGameMenuPrefab;

        public Installer(GameObject endGameMenuPrefab)
        {
            _endGameMenuPrefab = endGameMenuPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_endGameMenuPrefab);

            Container.Bind<IEndGamePresenter>().To<EndGamePresenter>().AsSingle().Lazy();

            Container.Bind<IInteractor<DeactivateCommand>>().To<DeactivateInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<ActivateCommand>>().To<ActivateInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<ReloadMapCommand>>().To<ReloadMapInteractor>().AsSingle().Lazy();

            Container.Bind<MapConnector>().AsTransient().Lazy();

            Container.BindSignal<GameStatusChanged>().ToMethod<MapConnector>(c => c.GameStatusChange).FromResolve();
        }
    }
}