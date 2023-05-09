using Core;
using Features.Camera.Adapters;

namespace Features.Camera.Handler
{
    public class LookAtHandler : IHandler<LookAtCommand>
    {
        private readonly ICameraPresenter _presenter;

        public LookAtHandler(ICameraPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Invoke(LookAtCommand command)
        {
            _presenter.LookAt(command.X, command.Y, command.Immediately);
        }
    }
}