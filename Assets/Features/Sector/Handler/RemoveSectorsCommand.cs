namespace Features.Sector.Handler
{
    public class RemoveSectorsCommand
    {
    }

    public interface IRemoveSectorsHandler
    {
        public void Invoke(RemoveSectorsCommand command);
    }
}