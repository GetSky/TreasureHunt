using Features.Sector.Domain.Events;
using Features.Sector.UseCases;
using Features.Sector.UseCases.OpenSector;

namespace Features.Sector.EventHandlers
{
    public class SectorClickedHandler
    {
        private readonly IInteractor<OpenSectorCommand> _interactor;

        public SectorClickedHandler(IInteractor<OpenSectorCommand> interactor)
        {
            _interactor = interactor;
        }

        public void Handle(SectorClicked domainEvent)
        {
            _interactor.Execute(new OpenSectorCommand(domainEvent.X, domainEvent.Z));
        }
    }
}