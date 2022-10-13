using Features.EndGameMenu;
using Features.EndGameMenu.View;
using Features.Map;
using Features.Sector;
using UnityEngine;
using Zenject;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private GameObject _endGameMenuPrefab;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            SectorInstaller.Install(Container, _groundPrefab);
            MapInstaller.Install(Container);
        }

        public void Awake()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            var map = Container.Resolve<Features.Map.Factory>().Create();
            var endMenu = Container.InstantiatePrefabForComponent<EndGameMenu>(_endGameMenuPrefab);
            var model = new EndGameMenuModel(map);
            model.AddView(endMenu);

            Container.Resolve<MapProducer>().Generate(10, 10, 90);
        }
    }
}