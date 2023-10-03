using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class RandomSectorsEffect : IEffect
    {
        private readonly int _grade;

        public RandomSectorsEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            if (openSector.Opened) return null;

            return new RandomSectorsDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.RandomOpen, _grade, _grade)
            );
        }
    }
}