namespace Core
{
    public interface IInteractor<in T> where T : ICommand
    {
        public void Execute(T command);
    }
}