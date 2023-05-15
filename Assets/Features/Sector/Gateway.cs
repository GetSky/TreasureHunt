using Features.Sector.UseCases;
using Features.Sector.UseCases.CreateSector;
using Features.Sector.UseCases.OpenSector;
using UnityEngine;

namespace Features.Sector
{
    public class Gateway
    {
        private readonly IInteractor<CreateSectorCommand> _interactor;
        private readonly IInteractor<OpenSectorCommand> _interactorO;

        public Gateway(IInteractor<CreateSectorCommand> interactor, IInteractor<OpenSectorCommand> interactorO)
        {
            _interactor = interactor;
            _interactorO = interactorO;
            Debug.Log("Sector gateway start...");
        }

        public void Schedule(ICommand command)
        {
            switch (command)
            {
                case CreateSectorCommand sectorCommand:
                    _interactor.Execute(sectorCommand);
                    break;
                case OpenSectorCommand sectorCommand:
                    _interactorO.Execute(sectorCommand);
                    break;
            }
        }
    }
}