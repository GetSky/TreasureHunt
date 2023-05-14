using Features.Sector.UseCases;
using Features.Sector.UseCases.CreateSector;
using UnityEngine;

namespace Features.Sector
{
    public class Gateway
    {
        private readonly IInteractor<CreateSectorCommand> _interactor;

        public Gateway(IInteractor<CreateSectorCommand> interactor)
        {
            _interactor = interactor;
            Debug.Log("Sector gateway start...");
        }

        public void Schedule(ICommand command)
        {
            _interactor.Execute((CreateSectorCommand) command);
        }
    }
}