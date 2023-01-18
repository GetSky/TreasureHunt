using TMPro;
using UnityEngine;

namespace Features.Player.View
{
    public class CoinsView : MonoBehaviour, ICoinsView
    {
        private int _count;
        [SerializeField] private TMP_Text _input;

        public void UpdateCoins(int count)
        {
            _count = count;
            _input.SetText(count.ToString());
        }
    }
}