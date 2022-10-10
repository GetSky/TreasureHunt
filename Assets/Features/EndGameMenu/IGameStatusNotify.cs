using System;

namespace Features.EndGameMenu
{
    public interface IGameStatusNotify
    {
        delegate void StatusHandler(bool active);
        public event StatusHandler Notify;
    }
}