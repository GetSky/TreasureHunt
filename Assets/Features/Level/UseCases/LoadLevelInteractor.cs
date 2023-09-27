using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Domain;

namespace Features.Level.UseCases
{
    public class LoadLevelInteractor : IInteractor<LoadLevelCommand>
    {
        private readonly LevelProducer _producer;
        private readonly ILevelContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public LoadLevelInteractor(LevelProducer producer, ILevelContext context, IEnergyPresenterBoundary presenter)
        {
            _producer = producer;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(LoadLevelCommand command)
        {
            var level = _producer.Generate(10, 10, 10, 20, 5, 5, 5, 5, 55);
            _presenter.UpdateEnergy(6);
            _context.Save(level);
        }
    }
}