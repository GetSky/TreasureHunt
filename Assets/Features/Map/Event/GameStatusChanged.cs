namespace Features.Map.Event
{
    public class GameStatusChanged : IDomainEvent
    {
        public bool Active { get; }

        public GameStatusChanged(bool isActive)
        {
            Active = isActive;
        }
    }
}