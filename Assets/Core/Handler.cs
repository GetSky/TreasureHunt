namespace Core
{
    public interface IHandler<in T>
    {
        public void Invoke(T command);
    }
}