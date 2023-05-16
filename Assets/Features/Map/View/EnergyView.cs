using Features.Map.Adapters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.Map.View
{
    public class EnergyView : MonoBehaviour
    {
        private Image[] _energy;
        private IEnergyPresenter _presenter;

        [Inject]
        public void Construct(IEnergyPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Awake()
        {
            _energy = gameObject.GetComponentsInChildren<Image>();
        }

        public void UpdateEnergy(int count)
        {
            for (var i = 0; i < _energy.Length; i++) 
                _energy[i].gameObject.SetActive(i <= count);
        }

        private void OnEnable()
        {
            _presenter.OnUpdatedEnergy += UpdateEnergy;
        }

        private void OnDisable()
        {
            _presenter.OnUpdatedEnergy -= UpdateEnergy;
        }
    }
}