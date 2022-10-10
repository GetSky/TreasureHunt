using Features.Map;
using Features.Map.Handler;
using UnityEngine;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace Features.EndGameMenu.View
{
    public class EndGameMenu : MonoBehaviour, IEndGameMenuView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private IRestartMapHandler _restartMapHandler;

        [Inject]
        public void Construct(IRestartMapHandler restartMapHandler)
        {
            _restartMapHandler = restartMapHandler;
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
            _restartMapHandler.Invoke(new RestartMapCommand());
        }

        private void OnClickExit()
        {
            Application.Quit();
        }
    }
}