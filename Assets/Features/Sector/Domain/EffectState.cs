namespace Features.Sector.Domain
{
    public enum EffectStateType
    {
        Empty,
        Distance,
        TooFar,
        Treasure,
        Coin,
        Energy,
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