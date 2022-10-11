namespace Features.Map.Event
{
    public class GameStatusChange : IDomainEvent
    {
        public bool Active { get; }

        public GameStatusChange(bool isActive)
        {
            Active = isActive;
        }
    }
}