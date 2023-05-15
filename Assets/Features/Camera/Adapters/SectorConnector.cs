﻿using Core;
using Features.Camera.Commands;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;

namespace Features.Camera.Adapters
{
    public class SectorConnector
    {
        private readonly IInteractor<LookAtCommand> _interactor;

        public SectorConnector(IInteractor<LookAtCommand> interactor)
        {
            _interactor = interactor;
        }

        public void FoundTreasure(TreasureDiscovered status)
        {
            _interactor.Execute(new LookAtCommand(status.X, status.Y, false));
        }
    }
}