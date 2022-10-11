using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class DeactivateMapHandler : IDeactivateMapHandler
    {
        private readonly IMapRepository _mapRepo;
        private readonly IMapFlasher _mapFlasher;

        public DeactivateMapHandler(IMapRepository mapRepo, IMapFlasher mapFlasher)
        {
            _mapRepo = mapRepo;
            _mapFlasher = mapFlasher;
        }

        public void Invoke(DeactivateMapCommand command)
        {
            var map = _mapRepo.FindCurrent();
            map.Deactivate();
            _mapFlasher.Save(map);
        }
    }
}