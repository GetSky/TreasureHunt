using Core;

namespace Features.Sector.Handler
{
    public class CreateSectorCommand : ICommand
    {
        public float X { get; }
        public float Z { get; }
        public string Type { get; }

        public CreateSectorCommand(float x, float z, string type)
        {
            X = x;
            Z = z;
            Type = type;
        }
    }
}