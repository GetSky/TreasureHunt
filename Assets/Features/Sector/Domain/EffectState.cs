namespace Features.Sector.Domain
{
    public enum EffectStateType
    {
        Empty,
        Distance,
        Direction,
        TooFar,
        Treasure,
        Coin,
        Energy,
        RandomOpen
    }

    public struct EffectState
    {
        public EffectStateType Type { get; }
        public int Grade { get; }
        public int Value { get; }

        public EffectState(EffectStateType type, int grade, int value)
        {
            Type = type;
            Grade = grade;
            Value = value;
        }
    }
}