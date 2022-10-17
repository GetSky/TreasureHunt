using Features.EndGameMenu.Handler;
using Features.EndGameMenu.Repository;
using Features.Map.Event;
using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class EndGameMenuInstaller : Installer<GameObject, EndGameMenuInstaller>
    {
        private readonly GameObject _endGameMenuPrefab;

        public EndGameMenuInstaller(GameObject endGameMenuPrefab)
        {
            _endGameMenuPrefab = endGameMenuPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_endGameMenuPrefab);

            Container.Bind<IDeactivateMenuHandler>().To<DeactivateMenuHandler>().AsSingle().Lazy();
            Container.Bind<IActivateMenuCommand>().To<ActivateMenuHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IEndMenuContext), typeof(IEndMenuRepository))
                .To<SceneEndMenuRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MapConnector>().AsTransient().Lazy();
            Container.BindSignal<GameStatusChange>().ToMethod<MapConnector>(c => c.GameStatusChange).FromResolve();
        }
    }
}