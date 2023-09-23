using Core;
using Features.EndGameMenu.Adapters;
using Features.EndGameMenu.UseCases;
using Features.Level.Event;
using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class EndGameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _endGameMenuPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("EndGameMenu")
                .AsSingle()
                .NonLazy();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();

            subContainer.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(subContainer, _endGameMenuPrefab);

            subContainer.Bind<IEndGamePresenter>().To<EndGamePresenter>().AsSingle().Lazy();

            subContainer.Bind<IInteractor<DeactivateCommand>>().To<DeactivateInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<ActivateCommand>>().To<ActivateInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<ReloadMapCommand>>().To<ReloadMapInteractor>().AsSingle().Lazy();

            subContainer.Bind<MapConnector>().AsTransient().Lazy();

            subContainer.BindSignal<GameStatusChanged>().ToMethod<MapConnector>(c => c.GameStatusChange).FromResolve();
        }
    }
}