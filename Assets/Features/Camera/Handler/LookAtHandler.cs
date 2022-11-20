using Features.Camera.Repository;

namespace Features.Camera.Handler
{
    public class LookAtHandler : ILookAtHandler
    {
        private readonly IModelRepository _repository;

        public LookAtHandler(IModelRepository repository)
        {
            _repository = repository;
        }

        public void Invoke(LookAtCommand command)
        {
            var cameraModel = _repository.FindFirst();
            cameraModel?.LookAt(command.X, command.Y);
        }
    }
}