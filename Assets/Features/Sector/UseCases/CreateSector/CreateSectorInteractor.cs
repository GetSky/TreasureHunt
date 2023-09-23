using System;
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
            if (Enum.TryParse(command.Type, true, out EffectType effectType) == false) return;
            var sector = _factory.Create(command.X, command.Z, effectType);
            _repository.Add(sector);
        }
    }
}