﻿namespace Features.OldSector.Entities
{
    public interface ISectorRepository
    {
        public Sector[] FindAll();
        public Sector FindById(string id);
        public Sector FindTreasure();
        public Sector[] FindInactive();
    }
}