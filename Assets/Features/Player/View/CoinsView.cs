using Features.Player.Adapters;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Player.View
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _input;

        private ICoinPresenter _presenter;

        [Inject]
        public void Construct(ICoinPresenter presenter)
        {
            _presenter = presenter;
        }

        private void UpdateCoins(int count)
        {
            _input.SetText(count.ToString());
        }

        private void OnEnable()
        {
            _presenter.OnUpdatedCoins += UpdateCoins;
            UpdateCoins(_presenter.CurrentCounts());
        }

        private void OnDisable()
        {
            _presenter.OnUpdatedCoins -= UpdateCoins;
        }
    }
}