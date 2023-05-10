using UnityEngine;
using Zenject;

namespace Features.Camera
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _cameraPrefab;

        public Initializer(DiContainer container, GameObject cameraPrefab)
        {
            _container = container;
            _cameraPrefab = cameraPrefab;
        }

        public void Initialize()
        {
            _container.InstantiatePrefabForComponent<View.CameraControl>(_cameraPrefab);
        }
    }
}