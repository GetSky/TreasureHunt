using Features.EndGameMenu.Repository;
using UnityEngine;
using Zenject;

namespace Features.EndGameMenu
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly GameObject _endGameMenuPrefab;
        private readonly IModelContext _context;

        public Initializer(DiContainer container, GameObject endGameMenuPrefab, IModelContext context)
        {
            _container = container;
            _endGameMenuPrefab = endGameMenuPrefab;
            _context = context;
        }

        public void Initialize()
        {
            var endMenu = _container.InstantiatePrefabForComponent<View.EndGameMenu>(_endGameMenuPrefab);
            var model = new MenuModel();
            model.AddView(endMenu);
            _context.Save(model);
        }
    }
}