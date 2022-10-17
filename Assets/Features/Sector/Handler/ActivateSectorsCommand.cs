namespace Features.Sector.Handler
{
    public class ActivateSectorsCommand
    {
    }

    public interface IActivateSectorsHandler
    {
        public void Invoke(ActivateSectorsCommand command);
    }
}