using System;
using System.Numerics;
using Core;
using Features.Sector.Card;

namespace Features.Sector.Handler
{
    public class CreateSectorHandler : IHandler<CreateSectorCommand>
    {
        private readonly Factory _factory;

        public CreateSectorHandler(Factory factory)
        {
            _factory = factory;
        }

        public void Invoke(CreateSectorCommand command)
        {
            if (Enum.TryParse(command.Type, true, out CardType card) == false) return;
            _factory.Create(new Vector2(command.X, command.Z), card);
        }
    }
}