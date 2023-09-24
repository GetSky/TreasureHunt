namespace Features.Level.Entity
{
    public interface ILevelContext
    {
        public void Save(Level level);

        public void Clear();
    }
}