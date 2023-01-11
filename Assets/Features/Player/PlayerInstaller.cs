using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class PlayerInstaller : Installer<GameObject, PlayerInstaller>
    {
        private readonly GameObject _coinsCounterPrefab;

        public PlayerInstaller(GameObject coinsCounterPrefab)
        {
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Initializer>().AsSingle().WithArguments(_coinsCounterPrefab);
        }
    }
}