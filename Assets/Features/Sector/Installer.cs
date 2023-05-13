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

            subContainer
                .BindFactory<Sector, Factory>()
                .FromSubContainerResolve()
                .ByMethod(InstallSector)
                .AsSingle();
        }

        private void InstallSector(DiContainer subContainer)
        {
            subContainer.Bind<Sector>().AsSingle();
            subContainer.Bind<SectorPresenter>().AsSingle();
            subContainer.InstantiatePrefabForComponent<SectorView>(_prefab);
        }
    }
}