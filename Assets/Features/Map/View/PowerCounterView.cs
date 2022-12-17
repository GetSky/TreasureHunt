using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Map.View
{
    public class PowerCounterView : MonoBehaviour, IPowerCountView
    {
        [SerializeField] private GameObject _power;

        public void UpdatePower(int count)
        {
            var powers = gameObject.GetComponentsInChildren<Image>();
            var diff = (powers.Length - 1) - count;
            if (diff > 0)
            {
                for (var i = diff; i > 0; i--) Destroy(powers[powers.Length - i].gameObject);
            }
            else
            {
                for (var i = 1; i <= Math.Abs(diff); i++) Instantiate(_power, gameObject.transform, false);
            }
        }
    }
}