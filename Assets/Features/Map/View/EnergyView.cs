using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Map.View
{
    public class EnergyView : MonoBehaviour, IEnergyView
    {
        private Image[] _energy;

        public void Awake()
        {
            _energy = gameObject.GetComponentsInChildren<Image>();
        }

        public void UpdateEnergy(int count)
        {
            for (var i = 0; i < _energy.Length; i++) 
                _energy[i].gameObject.SetActive(i <= count);
        }
    }
}