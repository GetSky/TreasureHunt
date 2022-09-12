﻿using System;
using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        public string Id { get; }
        private Vector2 Position { get; }
        public Card Card { get; }

        public Action<string> OnOpened = delegate { };
        public Action OnHighlighted = delegate { };
        public Action OnStopHighlighted = delegate { };

        public Sector(string id, Vector2 position, Card card)
        {
            Id = id;
            Position = position;
            Card = card;
        }

        public void Open(Sector treasure)
        {
            if (Card.Type == CardType.Treasure)
            {
                OnOpened("X");
                return;
            }

            var distance = DistanceTo(treasure);
            OnOpened.Invoke(Card.Type == CardType.Distance && distance <= 6 ? distance.ToString() : "?");
        }

        public void Highlight(Sector treasure, Sector openedSector)
        {
            var distance = openedSector.DistanceTo(treasure);
            if (distance == DistanceTo(openedSector) && distance <= 6) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        private int DistanceTo(Sector sector)
        {
            return (int)Math.Round(Math.Sqrt(
                Math.Pow(Position.X - sector.Position.X, 2) +
                Math.Pow(Position.Y - sector.Position.Y, 2)
            ));
        }
    }
}