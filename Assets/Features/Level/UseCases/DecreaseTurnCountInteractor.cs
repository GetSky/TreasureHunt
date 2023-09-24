﻿using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Entity;

namespace Features.Level.UseCases
{
    public class DecreaseTurnCountInteractor : IInteractor<DecreaseTurnCountCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public DecreaseTurnCountInteractor(
            IMapRepository repository,
            IMapContext context,
            IEnergyPresenterBoundary presenter
        )
        {
            _repository = repository;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(DecreaseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            _presenter.UpdateEnergy(map.DecreaseTurnCount());
            _context.Save(map);
        }
    }
}