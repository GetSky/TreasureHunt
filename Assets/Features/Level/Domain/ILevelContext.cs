namespace Features.Level.Domain
{
    public interface ILevelContext
    {
        public void Save(Level level);

        public void Clear();
    }
}