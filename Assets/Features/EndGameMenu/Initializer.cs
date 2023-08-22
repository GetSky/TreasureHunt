using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public Initializer(DiContainer container, GameObject prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public void Initialize()
        {
            _container.InstantiatePrefab(_prefab).gameObject.SetActive(false);
        }
    }
}