using Features.Camera.Handler;
using Features.Camera.Repository;
using Features.Map.Event;
using Features.Sector.Event;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Zenject;
using IModelContext = Features.Camera.Repository.IModelContext;

namespace Features.Camera
{
    public class CameraInstaller : Installer<GameObject, CameraInstaller>
    {
        private readonly GameObject _cameraPrefab;

        public CameraInstaller(GameObject cameraPrefab)
        {
            _cameraPrefab = cameraPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_cameraPrefab);

            Container.Bind<ILookAtHandler>().To<LookAtHandler>().AsSingle().Lazy();
            
            Container
                .Bind(typeof(IModelContext), typeof(IModelRepository))
                .To<MemoryModelRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MapConnector>().AsTransient().Lazy();
            Container.BindSignal<TreasureFound>().ToMethod<MapConnector>(c => c.FoundTreasure).FromResolve();
        }
    }

    public class LookAtHandler : ILookAtHandler
    {
        private readonly IModelRepository _repository;

        public LookAtHandler(IModelRepository repository)
        {
            _repository = repository;
        }
        public void Invoke(LookAtCommand command)
        {
            var cameraModel = _repository.FindFirst();
            cameraModel?.LookAt(command.X, command.Y, command.Z);
        }
    }
}