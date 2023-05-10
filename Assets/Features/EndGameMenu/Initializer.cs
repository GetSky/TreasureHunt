using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _endGameMenuPrefab;

        public Initializer(DiContainer container, GameObject endGameMenuPrefab)
        {
            _container = container;
            _endGameMenuPrefab = endGameMenuPrefab;
        }

        public void Initialize()
        {
            _container.InstantiatePrefabForComponent<View.EndGameMenu>(_endGameMenuPrefab);
        }
    }
}