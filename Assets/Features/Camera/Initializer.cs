using Features.Camera.Repository;
using UnityEngine;
using Zenject;

namespace Features.Camera
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _cameraPrefab;
        private readonly IModelContext _context;

        public Initializer(DiContainer container, GameObject cameraPrefab, IModelContext context)
        {
            _container = container;
            _cameraPrefab = cameraPrefab;
            _context = context;
        }

        public void Initialize()
        {
            var camera = _container.InstantiatePrefabForComponent<View.CameraController>(_cameraPrefab);
            var model = new CameraModel();
            model.AddView(camera);
            _context.Save(model);
        }
    }
}
