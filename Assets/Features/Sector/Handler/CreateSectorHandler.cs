using System;
using System.Numerics;
using Core;
using Features.Sector.Card;

namespace Features.Sector.Handler
{
    public class CreateSectorInteractor : IInteractor<CreateSectorCommand>
    {
        private readonly Factory _factory;

        public CreateSectorInteractor(Factory factory)
        {
            _factory = factory;
        }

        public void Execute(CreateSectorCommand command)
        {
            if (Enum.TryParse(command.Type, true, out CardType card) == false) return;
            _factory.Create(new Vector2(command.X, command.Z), card);
        }
    }
}