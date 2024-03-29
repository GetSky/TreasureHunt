﻿using Features.Level.Adapters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.Level.View
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

        private void UpdateEnergy(int count)
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