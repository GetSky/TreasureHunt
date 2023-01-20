namespace Features.Sector.Handler
{
    public class SectorOpenCommand
    {
        public string Id { get; }

        public SectorOpenCommand(string id) => Id = id;
    }
}