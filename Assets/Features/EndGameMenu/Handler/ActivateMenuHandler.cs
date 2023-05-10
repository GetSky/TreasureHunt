using Core;
using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class ActivateInteractor : IInteractor<ActivateCommand>
    {
        private readonly IModelRepository _repo;

        public ActivateInteractor(IModelRepository repo)
        {
            _repo = repo;
        }

        public void Execute(ActivateCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(true);
        }
    }
}