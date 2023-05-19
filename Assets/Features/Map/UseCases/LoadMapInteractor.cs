using Core;
using Features.Map.Adapters;
using Features.Map.Commands;
using Features.Map.Entity;

namespace Features.Map.UseCases
{
    public class LoadMapInteractor : IInteractor<LoadMapCommand>
    {
        private readonly MapProducer _producer;
        private readonly IMapContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public LoadMapInteractor(MapProducer producer, IMapContext context, IEnergyPresenterBoundary presenter)
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