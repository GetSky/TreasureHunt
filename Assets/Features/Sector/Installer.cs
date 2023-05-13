using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;

        public override void InstallBindings()

        {
            Container.BindInterfacesAndSelfTo<SectorAPI>().FromSubContainerResolve().ByMethod(InstallGateway).AsSingle();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<SectorAPI>().AsSingle();

            subContainer.BindInterfacesAndSelfTo<SectorTick>().AsSingle();

            subContainer
                .Bind<Sector>()
                .FromSubContainerResolve()
                .ByMethod(InstallGreeter).AsTransient();
        }

        private void InstallGreeter(DiContainer subContainer)
        {
            subContainer.Bind<Sector>().AsSingle();
            subContainer.Bind<SectorPresenter>().AsSingle();
            subContainer.InstantiatePrefabForComponent<SectorView>(_prefab);
        }
    }
}