using System;
using System.Numerics;
using Core;
using Features.Sector.Card;
using Features.Sector.Commands;
using Features.Sector.Entities;

namespace Features.Sector.UseCases
{
    public class CreateSectorInteractor : IInteractor<CreateSectorCommand>
    {
        private readonly Factory _factory;
        private readonly ISectorContext _context;

        public CreateSectorInteractor(Factory factory, ISectorContext context)
        {
            _factory = factory;
            _context = context;
        }

        public void Execute(CreateSectorCommand command)
        {
            if (Enum.TryParse(command.Type, true, out CardType card) == false) return;
            var sector = _factory.Create(new Vector2(command.X, command.Z), card);
            _context.Save(sector);
        }
    }
}