namespace Features.Sector.UseCases.ClickOnSector
{
    public class ClickOnSectorCommand : ICommand
    {
        public float X { get; }

        public float Z { get; }

        public ClickOnSectorCommand(float x, float z)
        {
            X = x;
            Z = z;
        }
    }
}