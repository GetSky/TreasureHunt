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

            Container.Bind<IDeactivateHandler>().To<DeactivateHandler>().AsSingle().Lazy();
            Container.Bind<IActivateCommand>().To<ActivateHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IModelContext), typeof(IModelRepository))
                .To<MemoryModelRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MapConnector>().AsTransient().Lazy();
            Container.BindSignal<GameStatusChanged>().ToMethod<MapConnector>(c => c.GameStatusChange).FromResolve();
        }
    }
}