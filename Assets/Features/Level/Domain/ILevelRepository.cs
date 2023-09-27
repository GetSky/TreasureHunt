namespace Features.Level.Domain
{
    public interface ILevelRepository
    {
        public Level FindCurrent();
    }
}