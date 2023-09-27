namespace Features.Level.Domain
{
    public class Energy
    {
        private readonly int _max;
        private int _current;

        public Energy(int current)
        {
            _max = current;
            _current = _max;
        }

        public void BoostBy(int count)
        {
            _current += count;
        }

        public bool Decrease()
        {
            if (_current == 0) return false;
            _current--;
            return true;
        }

        public bool IsRanOut() => _current == 0;

        public void Reset() => _current = _max;

        public int Count() => _current;
    }
}