using Core.PlayerController;
using Features.Camera.View;
using UnityEngine;
using Zenject;
using IInputSectorControl = Features.Sector.View.IInputSectorControl;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
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