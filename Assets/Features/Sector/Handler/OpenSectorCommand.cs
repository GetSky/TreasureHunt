using Core;

namespace Features.Sector.Handler
{
    public class SectorOpenCommand : ICommand
    {
        public string Id { get; }

        public SectorOpenCommand(string id) => Id = id;
    }
}