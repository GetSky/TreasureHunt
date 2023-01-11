using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _coinsCounterPrefab;

        public Initializer(DiContainer container, GameObject coinsCounterPrefab)
        {
            _container = container;
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public void Initialize()
        { 
            _container.InstantiatePrefab(_coinsCounterPrefab);
        }
    }
}