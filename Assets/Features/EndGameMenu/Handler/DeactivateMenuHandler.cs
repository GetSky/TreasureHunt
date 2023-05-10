using Core;
using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class DeactivateInteractor : IInteractor<DeactivateCommand>
    {
        private readonly IModelRepository _repo;

        public DeactivateInteractor(IModelRepository repo)
        {
            _repo = repo;
        }

        public void Execute(DeactivateCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(false);
        }
    }
}