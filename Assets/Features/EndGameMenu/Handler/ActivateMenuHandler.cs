using Core;
using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class ActivateHandler : IHandler<ActivateCommand>
    {
        private readonly IModelRepository _repo;

        public ActivateHandler(IModelRepository repo)
        {
            _repo = repo;
        }

        public void Invoke(ActivateCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(true);
        }
    }
}