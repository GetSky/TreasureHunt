namespace Features.Map.Event
{
    public class GameStatusChange : IDomainEvent
    {
        private bool Active { get; }

        public GameStatusChange(bool isActive)
        {
            Active = isActive;
        }
    }
}