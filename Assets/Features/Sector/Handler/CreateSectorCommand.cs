namespace Features.Sector.Handler
{
    public class CreateSectorCommand
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

    public interface ICreateSectorHandler
    {
        public void Invoke(CreateSectorCommand command);
    }
}