using Core;
using Features.Camera.Adapters;
using Features.Camera.Commands;

namespace Features.Camera.UseCases
{
    public class LookAtInteractor : IInteractor<LookAtCommand>
    {
        private readonly CameraPresenter _presenter;

        public LookAtInteractor(CameraPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Execute(LookAtCommand command)
        {
            _presenter.LookAt(command.X, command.Y, command.Immediately);
        }
    }
}