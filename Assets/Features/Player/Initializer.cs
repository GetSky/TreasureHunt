using Features.Player.Repository;
using Zenject;

namespace Features.Player
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly IPlayerContext _context;

        public Initializer(Factory factory, IPlayerContext context)
        {
            _factory = factory;
            _context = context;
        }

        public void Initialize()
        {
            var entity = _factory.Create("local", 0);
            _context.Save(entity);
        }
    }
}