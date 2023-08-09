using Features.Sector.UseCases;
using Features.Sector.UseCases.ClickOnSector;
using Features.Sector.UseCases.CreateSector;
using UnityEngine;

namespace Features.Sector
{
    public class Gateway
    {
        private readonly IInteractor<CreateSectorCommand> _createSector;
        private readonly IInteractor<ClickOnSectorCommand> _clickOnSector;

        public Gateway(IInteractor<CreateSectorCommand> createSector, IInteractor<ClickOnSectorCommand> clickOnSector)
        {
            _createSector = createSector;
            _clickOnSector = clickOnSector;
            Debug.Log("Sector gateway start...");
        }

        public void Schedule(ICommand command)
        {
            switch (command)
            {
                case CreateSectorCommand sectorCommand:
                    _createSector.Execute(sectorCommand);
                    break;
                case ClickOnSectorCommand sectorCommand:
                    _clickOnSector.Execute(sectorCommand);
                    break;
            }
        }
    }
}