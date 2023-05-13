using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;

        public override void InstallBindings()

        {
            Container
                .Bind<SectorAPI>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("Sector API Gateway")
                .AsSingle()
                .NonLazy();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<SectorAPI>().AsSingle();

            subContainer.BindInterfacesAndSelfTo<SectorTick>().AsSingle().NonLazy();

            subContainer
                .Bind<Sector>()
                .FromSubContainerResolve()
                .ByMethod(InstallGreeter).AsTransient().Lazy();
        }

        private void InstallGreeter(DiContainer subContainer)
        {
            subContainer.Bind<Sector>().AsSingle();
            subContainer.Bind<SectorPresenter>().AsSingle();
            subContainer.InstantiatePrefabForComponent<SectorView>(_prefab);
        }
    }
}