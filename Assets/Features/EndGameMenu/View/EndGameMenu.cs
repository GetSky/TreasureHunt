using Features.Map.Handler;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.EndGameMenu.View
{
    public class EndGameMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private IRestartMapHandler _restartMapHandler;

        [Inject]
        public void Construct(IRestartMapHandler restartMapHandler)
        {
            _restartMapHandler = restartMapHandler;
        }

        private void Start()
        {
            _playButton.onClick.AddListener(OnClickPlay);
            _exitButton.onClick.AddListener(OnClickExit);
        }

        private void OnClickPlay()
        {
            _restartMapHandler.Invoke(new RestartMapCommand());
        }

        private void OnClickExit()
        {
            Application.Quit();  
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnClickPlay);
            _exitButton.onClick.RemoveListener(OnClickExit);
        }
    }
}