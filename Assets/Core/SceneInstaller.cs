using Core.PlayerController;
using Features.Camera;
using Features.Camera.View;
using Features.EndGameMenu;
using Features.Map;
using Features.Sector;
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

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            SectorInstaller.Install(Container, _groundPrefab);
            EndGameMenuInstaller.Install(Container, _endGameMenuPrefab);
            CameraInstaller.Install(Container, _cameraPrefab);
            MapInstaller.Install(Container);
            
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