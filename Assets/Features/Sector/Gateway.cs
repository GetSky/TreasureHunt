using Features.Sector.UseCases;
using Features.Sector.UseCases.ClickOnSector;
using Features.Sector.UseCases.CreateSector;
using Features.Sector.UseCases.OpenSector;
using UnityEngine;

namespace Features.Sector
{
    public class Gateway
    {
        private readonly IInteractor<CreateSectorCommand> _interactor;
        private readonly IInteractor<ClickOnSectorCommand> _interactorO;

        public Gateway(IInteractor<CreateSectorCommand> interactor, IInteractor<ClickOnSectorCommand> interactorO)
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
                case ClickOnSectorCommand sectorCommand:
                    _interactorO.Execute(sectorCommand);
                    break;
            }
        }
    }
}