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
            EndGameMenuInstaller.Install(Container, _endGameMenuPrefab);
            MapInstaller.Install(Container);
        }
    }
}