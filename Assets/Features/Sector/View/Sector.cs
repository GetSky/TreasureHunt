using System.Collections;
using DG.Tweening;
using Features.Sector.Handler;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class Sector : MonoBehaviour, ISymbolView, IHighlightedView
    {
        [SerializeField] private Color _defaultColor = Color.white;
        [SerializeField] private Color _highlightColor = Color.green;
        [SerializeField] private Color _pressingColor = Color.gray;
        [SerializeField] private Color _treasureColor = Color.yellow;
        [SerializeField] private Color _distanceColor = Color.cyan;

        [SerializeField] private float _timeAnimationDuration = 0.75f;
        [SerializeField] private float _timeAnimationDelay = 2.0f;

        private TextMeshPro _distanceText;
        private ISectorOpenHandler _openHandler;
        private Material _material;
        private bool _isOpened;
        private bool _isFinished;

        [Inject]
        public void Construct(ISectorOpenHandler openHandler)
        {
            _openHandler = openHandler;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
            _material = GetComponent<MeshRenderer>().material;
            _material.color = _defaultColor;
        }

        public string UniqueCode() => transform.position + gameObject.name;

        private void OnMouseDown()
        {
            _openHandler.Invoke(new SectorOpenCommand(UniqueCode()));
        }

        public void UpdateSymbol(string symbol)
        {
            _distanceText.SetText(symbol);
            StopHighlight();
            _isOpened = true;
            switch (symbol)
            {
                case "?":
                case "-":
                    _material.DOColor(_pressingColor, _timeAnimationDuration);
                    break;
                case "X":
                    _isFinished = true;
                    _material.DOColor(_treasureColor, _timeAnimationDuration);
                    break;
                default:
                    _material.DOColor(_distanceColor, _timeAnimationDuration);
                    break;
            }
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void Highlight()
        {
            if (_isOpened) return;
            StopHighlight();

            _material.DOColor(_highlightColor, _timeAnimationDuration);
            _material
                .DOColor(_defaultColor, _timeAnimationDuration)
                .SetDelay(_timeAnimationDelay + _timeAnimationDuration);
        }

        public void StopHighlight()
        {
            if (_isOpened) return;
            _material.DOKill();
            _material.DOColor(_defaultColor, _timeAnimationDuration);
        }
    }
}