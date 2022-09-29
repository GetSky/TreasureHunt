using System.Collections;
using DG.Tweening;
using Features.Map.Handler;
using Features.Sector.Handler;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class Sector : MonoBehaviour, ISymbolView, IHighlightedView
    {
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _highlightColor;
        [SerializeField] private Color _pressingColor;
        [SerializeField] private Color _treasureColor;
        [SerializeField] private Color _distanceColor;

        [SerializeField] private float _timeAnimationDuration = 0.75f;
        [SerializeField] private float _timeRestartDuration = 0.75f;
        [SerializeField] private float _timeAnimationDelay = 2.0f;

        private TextMeshPro _distanceText;
        private IRestartMapHandler _restartMapHandler;
        private ISectorOpenHandler _openHandler;
        private Material _material;
        private bool _isOpened;
        private bool _isFinished;

        [Inject]
        public void Construct(ISectorOpenHandler openHandler, IRestartMapHandler restartMapHandler)
        {
            _openHandler = openHandler;
            _restartMapHandler = restartMapHandler;
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
                    _material.DOColor(_treasureColor, _timeAnimationDuration).onComplete += OnComplete;
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

        private void OnComplete()
        {
            if (_isFinished) StartCoroutine(nameof(RestartDelay));
        }

        private IEnumerator RestartDelay()
        {
            yield return new WaitForSeconds(_timeRestartDuration);
            _restartMapHandler.Invoke(new RestartMapCommand());
            StopCoroutine(nameof(RestartDelay));
        }

        public void StopHighlight()
        {
            if (_isOpened) return;
            _material.DOKill();
            _material.DOColor(_defaultColor, _timeAnimationDuration);
        }
    }
}