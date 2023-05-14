namespace Features.Sector
{
    public class SectorFactory
    {
        private readonly Factory _factory;

        public SectorFactory(Factory factory)
        {
            _factory = factory;
        }

        public Domain.Sector Create()
        {
            return _factory.Create();
        }
    }
}