namespace Features.Player.Entity
{
    public class CoinCounter
    {
        public int Count { get; private set; }

        public CoinCounter(int count)
        {
            Count = count;
        }

        public void Raise(int count)
        {
            if (count < 0) return;
            Count += count;
        }
    }
}