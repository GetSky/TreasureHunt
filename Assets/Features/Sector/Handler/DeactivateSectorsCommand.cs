namespace Features.Sector.Handler
{
    public class DeactivateSectorsCommand
    {
    }

    public interface IDeactivateSectorsHandler
    {
        public void Invoke(DeactivateSectorsCommand command);
    }
}