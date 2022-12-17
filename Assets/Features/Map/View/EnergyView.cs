using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Map.View
{
    public class EnergyView : MonoBehaviour, IEnergyView
    {
        [SerializeField] private GameObject _energyIcon;

        public void UpdateEnergy(int count)
        {
            var energy = gameObject.GetComponentsInChildren<Image>();
            var diff = (energy.Length - 1) - count;

            if (diff > 0)
                for (var i = diff; i > 0; i--)
                    Destroy(energy[energy.Length - i].gameObject);
            else
                for (var i = 1; i <= Math.Abs(diff); i++)
                    Instantiate(_energyIcon, gameObject.transform, false);
        }
    }
}