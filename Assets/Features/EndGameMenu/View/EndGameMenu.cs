using Core;
using Features.EndGameMenu.Adapters;
using Features.EndGameMenu.Commands;
using UnityEngine;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace Features.EndGameMenu.View
{
    public class EndGameMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private IEndGamePresenter _presenter;

        [Inject]
        public void Construct(IEndGamePresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnChangedStatus += SetVisible;
        }

        public void SetVisible(bool active)
        {
            gameObject.SetActive(active);
        }

        private void OnClickPlay()
        {
            _presenter.ReloadMap();
        }

        private static void OnClickExit()
        {
            Application.Quit();
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
    }
}