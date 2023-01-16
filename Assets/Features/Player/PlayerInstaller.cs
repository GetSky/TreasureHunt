using Features.Player.Repository;
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
            Container.Bind<IInitializable>().To<Initializer>().AsSingle();
            Container.Bind<Factory>().AsSingle().WithArguments(_coinsCounterPrefab).Lazy();

            Container
                .Bind(typeof(IPlayerContext), typeof(IPlayerRepository))
                .To<PrefsPlayerRepository>()
                .AsSingle()
                .NonLazy();
        }
    }
}