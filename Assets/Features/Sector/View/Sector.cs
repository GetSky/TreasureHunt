using Features.Sector.Handler;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    [RequireComponent(typeof(Animator))]
    public class Sector : MonoBehaviour, ISymbolView, IHighlightedView
    {
        private Animator _animator;
        private TextMeshPro _distanceText;
        private ISectorOpenHandler _openHandler;
        private bool _isTreasure;
        private static readonly int IsHighlight = Animator.StringToHash("isHighlight");

        [Inject]
        public void Construct(ISectorOpenHandler openHandler)
        {
            _animator = GetComponent<Animator>();
            _openHandler = openHandler;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
        }

        public void SetTreasure(bool isTreasure)
        {
            _isTreasure = isTreasure;
        }

        public string UniqueCode()
        {
            return transform.position + gameObject.name;
        }

        private void OnMouseDown()
        {
            _openHandler.Invoke(new SectorOpenCommand(UniqueCode()));
        }

        public void UpdateSymbol(string symbol)
        {
            _distanceText.SetText(symbol);
        }

        public void Highlight()
        {
            _animator.SetBool(IsHighlight, true);
        }

        public void StopHighlight()
        {
            _animator.SetBool(IsHighlight, false);
        }
    }
}