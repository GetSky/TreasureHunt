namespace Features.EndGameMenu.Handler
{
    public class ReloadMapHandler : IReloadMapHandler
    {
        private readonly IDeactivateHandler _deactivateHandler;
        private readonly Map.Handler.IReloadMapHandler _mapHandler;

        public ReloadMapHandler(IDeactivateHandler deactivateHandler, Map.Handler.IReloadMapHandler reloadMapHandler)
        {
            _deactivateHandler = deactivateHandler;
            _mapHandler = reloadMapHandler;
        }

        public void Invoke(ReloadMapCommand command)
        {
            _deactivateHandler.Invoke(new DeactivateCommand());
            _mapHandler.Invoke(new Map.Handler.ReloadMapCommand());
        }
    }
}