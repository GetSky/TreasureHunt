using Core;
using Features.Camera.Adapters;
using Features.Camera.Commands;
using Features.Camera.UseCases;
using Features.Level.Event;
using Features.Sector.Domain.Effects.Events;
using UnityEngine;
using Zenject;

namespace Features.Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _cameraPrefab;

        public override void InstallBindings()
        {
            InstallGateway();

            Container.DeclareSignal<LookAtCommand>();
        }

        private void InstallGateway()
        {
            Container
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGatewayBindings)
                .WithGameObjectName("Camera")
                .AsSingle()
                .NonLazy();
        }

        private void InstallGatewayBindings(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();

            subContainer.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_cameraPrefab);

            subContainer.Bind<ICameraPresenter>().To<CameraPresenter>().AsSingle().Lazy();

            subContainer.Bind<IInteractor<LookAtCommand>>().To<LookAtInteractor>().AsSingle().Lazy();
            subContainer
                .BindSignal<LookAtCommand>()
                .ToMethod<IInteractor<LookAtCommand>>(interactor => interactor.Execute)
                .FromResolve();

            subContainer.Bind<SectorConnector>().AsTransient().Lazy();
            subContainer.BindSignal<TreasureDiscovered>().ToMethod<SectorConnector>(c => c.FoundTreasure).FromResolve();

            subContainer.Bind<MapConnector>().AsTransient().Lazy();
            subContainer.BindSignal<MapLoaded>().ToMethod<MapConnector>(c => c.MapReload).FromResolve();
        }
    }
}