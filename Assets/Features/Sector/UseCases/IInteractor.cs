namespace Features.Sector.UseCases
{
    public interface IInteractor<in T> where T : ICommand
    {
        public void Execute(T command);
    }
}