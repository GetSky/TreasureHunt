using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class DeactivateHandler : IDeactivateHandler
    {
        private readonly IModelRepository _repo;

        public DeactivateHandler(IModelRepository repo)
        {
            _repo = repo;
        }

        public void Invoke(DeactivateCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(false);
        }
    }
}