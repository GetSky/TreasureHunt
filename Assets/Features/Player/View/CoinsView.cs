using TMPro;
using UnityEngine;

namespace Features.Player.View
{
    public class CoinsView : MonoBehaviour, ICoinsView
    {
        private int _count;
        [SerializeField] private GameObject input;

        public void Awake()
        {
            input.GetComponent<TextMeshProUGUI>().SetText("0");
        }

        public void UpdateCoins(int count)
        {
            input.GetComponent<TextMeshProUGUI>().SetText(count.ToString());
        }
    }
}