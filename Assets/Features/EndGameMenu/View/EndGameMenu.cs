using Core;
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

        private IInteractor<ReloadMapCommand> _reloadMapInteractor;

        [Inject]
        public void Construct(IInteractor<ReloadMapCommand> reloadMapInteractor)
        {
            _reloadMapInteractor = reloadMapInteractor;
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
            _reloadMapInteractor.Execute(new ReloadMapCommand());
        }

        private static void OnClickExit()
        {
            Application.Quit();
        }
    }
}