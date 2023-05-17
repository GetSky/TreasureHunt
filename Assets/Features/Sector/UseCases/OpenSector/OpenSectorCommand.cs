namespace Features.Sector.UseCases.OpenSector
{
    public class OpenSectorCommand : ICommand, Core.ICommand
    {
        public float X { get; }

        public float Z { get; }

        public OpenSectorCommand(float x, float z)
        {
            X = x;
            Z = z;
        }
    }
}