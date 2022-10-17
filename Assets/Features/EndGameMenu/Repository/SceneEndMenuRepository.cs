using System.Collections.Generic;
using System.Linq;

namespace Features.EndGameMenu.Repository
{
    public class SceneEndMenuRepository : IEndMenuContext, IEndMenuRepository
    {
        private readonly Dictionary<string, EndGameMenuModel> _endMenus = new Dictionary<string, EndGameMenuModel>();

        public void Save(EndGameMenuModel model)
        {
            _endMenus.Add(_endMenus.Count.ToString(), model);
        }

        public EndGameMenuModel FindFirst()
        {
            return _endMenus.First().Value;
        }
    }
}