namespace Features.Level.Entity
{
    public interface ILevelContext
    {
        public void Save(Map map);

        public void Clear();
    }
}