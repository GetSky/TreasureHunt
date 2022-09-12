using System.Collections;
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
            StopCoroutine(nameof(DelayStopHighlight));
            _animator.SetBool(IsHighlight, true);
            StartCoroutine(nameof(DelayStopHighlight));
        }

        public void StopHighlight()
        {
            StopCoroutine(nameof(DelayStopHighlight));
            _animator.SetBool(IsHighlight, false);
        }

        private IEnumerator DelayStopHighlight()
        {
            yield return new WaitForSeconds(1);
            StopHighlight();
        }
    }
}