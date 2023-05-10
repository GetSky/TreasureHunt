﻿using Core;
using Features.Map.Handler;
using Zenject;

namespace Features.Map
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly IInteractor<LoadMapCommand> _loadMapInteractor;

        public Initializer(Factory factory, IInteractor<LoadMapCommand> loadMapInteractor)
        {
            _factory = factory;
            _loadMapInteractor = loadMapInteractor;
        }

        public void Initialize()
        {
            _factory.Create();
            _loadMapInteractor.Execute(new LoadMapCommand());
        }
    }
}