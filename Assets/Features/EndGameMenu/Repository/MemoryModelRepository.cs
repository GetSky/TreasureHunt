using System.Collections.Generic;
using System.Linq;

namespace Features.EndGameMenu.Repository
{
    public class MemoryModelRepository : IModelContext, IModelRepository
    {
        private readonly Dictionary<string, MenuModel> _endMenus = new Dictionary<string, MenuModel>();

        public void Save(MenuModel model)
        {
            _endMenus.Add(_endMenus.Count.ToString(), model);
        }

        public MenuModel FindFirst()
        {
            return _endMenus.First().Value;
        }
    }
}