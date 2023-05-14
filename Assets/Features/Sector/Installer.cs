using Features.Sector.Domain;
using Features.Sector.UseCases;
using Features.Sector.UseCases.CreateSector;
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
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("Sectors")
                .AsSingle()
                .NonLazy();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();
            subContainer.BindInterfacesAndSelfTo<SectorTick>().AsSingle().NonLazy();

            subContainer.Bind<SectorFactory>().AsSingle().WithArguments(subContainer, _prefab);
            subContainer.Bind<ISectorRepository>().To<SectorMemoryRepository>().AsSingle();

            subContainer.Bind<IInteractor<CreateSectorCommand>>().To<CreateSectorInteractor>().AsTransient();
        }
    }
}