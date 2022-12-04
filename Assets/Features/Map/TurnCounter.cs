namespace Features.Map
{
    public class TurnCounter
    {
        private int _max;
        private int _current;

        public TurnCounter(int current)
        {
            _max = current;
            _current = _max;
        }

        public bool Decrease()
        {
            if (_current == 0) return false;
            _current--;
            return true;
        }

        public bool RanOut()
        {
            return _current == 0;
        }

        public void Reset()
        {
            _current = _max;
        }
    }
}