using Features.Sector.Domain;

namespace Features.Sector.UseCases.CreateSector
{
    public class CreateSectorInteractor : IInteractor<CreateSectorCommand>
    {
        private readonly SectorFactory _factory;
        private readonly ISectorRepository _repository;

        public CreateSectorInteractor(SectorFactory factory, ISectorRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Execute(CreateSectorCommand command)
        {
            var sector = _factory.Create(command.X, command.Z);
            _repository.Add(sector);
        }
    }
}