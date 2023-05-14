namespace Features.Sector.UseCases.OpenSector
{
    public class OpenSectorCommand : ICommand
    {
        public string Id { get; }

        public OpenSectorCommand(string id) => Id = id;
    }
}