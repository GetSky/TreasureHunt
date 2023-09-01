using Core.PlayerController;
using Features.Camera.View;
using UnityEngine;
using Zenject;
using IInputSectorControl = Features.Sector.View.IInputSectorControl;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _coinsCounterPrefab;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

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