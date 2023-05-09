using Core.PlayerController;
using Features.Camera.View;
using Features.Sector.View;
using UnityEngine;
using Zenject;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private GameObject _endGameMenuPrefab;
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private GameObject _energyCounterPrefab;
        [SerializeField] private GameObject _coinsCounterPrefab;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Features.Sector.Installer.Install(Container, _groundPrefab);
            Features.EndGameMenu.Installer.Install(Container, _endGameMenuPrefab);
            Features.Camera.Installer.Install(Container, _cameraPrefab);
            Features.Map.Installer.Install(Container, _energyCounterPrefab);
            Features.Player.Installer.Install(Container, _coinsCounterPrefab);

            var boundBinder = Container.Bind(typeof(IInputCameraControl), typeof(IInputSectorControl));
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    boundBinder.To<TouchControllerService>().AsSingle().NonLazy();
                    break;
                default:
                    boundBinder.To<MouseControllerService>().AsSingle().NonLazy();
                    break;
            }
        }
    }
}