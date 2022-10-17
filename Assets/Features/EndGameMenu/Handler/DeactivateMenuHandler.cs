using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class DeactivateMenuHandler : IDeactivateMenuHandler
    {
        private readonly IEndMenuRepository _repo;

        public DeactivateMenuHandler(IEndMenuRepository repo)
        {
            _repo = repo;
        }

        public void Invoke(DeactivateMenuCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(false);
        }
    }
}