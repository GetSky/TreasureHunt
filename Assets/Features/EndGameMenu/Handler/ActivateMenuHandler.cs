using Features.EndGameMenu.Repository;

namespace Features.EndGameMenu.Handler
{
    public class ActivateMenuHandler : IActivateMenuCommand
    {
        private readonly IEndMenuRepository _repo;

        public ActivateMenuHandler(IEndMenuRepository repo)
        {
            _repo = repo;
        }

        public void Invoke(ActivateMenuCommand command)
        {
            _repo.FindFirst().ChangeActiveStatus(true);
        }
    }
}