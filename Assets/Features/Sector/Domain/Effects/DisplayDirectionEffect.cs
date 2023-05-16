using System;
using Features.Sector.Domain.Effects.Events;
using UnityEngine;

namespace Features.Sector.Domain.Effects
{
    public class DisplayDirectionEffect : IEffect
    {
        private readonly int _grade;

        public DisplayDirectionEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            var direction = (int)Math.Round(openSector.MeasureDirectionTo(treasureSector));
            Debug.Log(treasureSector.Position.X + " " + treasureSector.Position.Y + " " + direction);

            return new HintDirectionDiscovered(
                openSector.Id,
                new EffectState(EffectStateType.Direction, _grade, direction)
            );
        }
    }
}