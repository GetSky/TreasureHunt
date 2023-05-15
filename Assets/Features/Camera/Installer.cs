using Core;
using Features.Camera.Adapters;
using Features.Camera.Commands;
using Features.Camera.UseCases;
using Features.Map.Event;
using Features.Sector.Domain.Events;
using UnityEngine;
using Zenject;

namespace Features.Camera
{
    public class Installer : Installer<GameObject, Installer>
    {
        private readonly GameObject _cameraPrefab;

        public Installer(GameObject cameraPrefab)
        {
            _cameraPrefab = cameraPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_cameraPrefab);

            Container.Bind<ICameraPresenter>().To<CameraPresenter>().AsSingle().Lazy();

            Container.Bind<IInteractor<LookAtCommand>>().To<LookAtInteractor>().AsSingle().Lazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();
            Container.BindSignal<TreasureDiscovered>().ToMethod<SectorConnector>(c => c.FoundTreasure).FromResolve();

            Container.Bind<MapConnector>().AsTransient().Lazy();
            Container.BindSignal<MapLoaded>().ToMethod<MapConnector>(c => c.MapReload).FromResolve();
        }
    }
}