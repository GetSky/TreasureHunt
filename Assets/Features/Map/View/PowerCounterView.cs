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
            for (var i = 1; i < powers.Length; i++) Destroy(powers[i].gameObject);
            for (var i = 1; i <= count; i++) Instantiate(_power, gameObject.transform, false);
        }
    }
}