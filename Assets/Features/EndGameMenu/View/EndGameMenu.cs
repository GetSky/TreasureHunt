using Features.EndGameMenu.Handler;
using UnityEngine;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace Features.EndGameMenu.View
{
    public class EndGameMenu : MonoBehaviour, IEndGameMenuView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private IReloadMapHandler _reloadMapHandler;

        [Inject]
        public void Construct(IReloadMapHandler reloadMapHandler)
        {
            _reloadMapHandler = reloadMapHandler;
        }

        public void SetVisible(bool active)
        {
            gameObject.SetActive(active);
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnClickExit);
            _playButton.onClick.AddListener(OnClickPlay);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnClickPlay);
            _exitButton.onClick.RemoveListener(OnClickExit);
        }

        private void OnClickPlay()
        {
            _reloadMapHandler.Invoke(new ReloadMapCommand());
        }

        private static void OnClickExit()
        {
            Application.Quit();
        }
    }
}