using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Entity;

namespace Features.Level.UseCases
{
    public class LoadMapInteractor : IInteractor<LoadMapCommand>
    {
        private readonly MapProducer _producer;
        private readonly ILevelContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public LoadMapInteractor(MapProducer producer, ILevelContext context, IEnergyPresenterBoundary presenter)
        {
            _producer = producer;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(LoadMapCommand command)
        {
            var map = _producer.Generate(10, 10, 10, 20, 5, 5, 5, 5, 55);
            _presenter.UpdateEnergy(6);
            _context.Save(map);
        }
    }
}