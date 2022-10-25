using System.Linq;
using DG.Tweening;
using Features.Sector.Handler;
using Features.Sector.View.State;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Features.Sector.View
{
    public class Sector : MonoBehaviour, ISymbolView, IHighlightedView
    {
        [FormerlySerializedAs("_timeAnimationDuration")] [SerializeField] private float _animationDuration = 0.75f;
        [FormerlySerializedAs("_timeAnimationDelay")] [SerializeField] private float _animationDelay = 2.0f;
        [SerializeField] private CardState[] _states;

        private IInputSectorControl _input;
        private ISectorOpenHandler _openHandler;
        private Material _material;
        private TextMeshPro _distanceText;
        private Color _lightColor;
        private Color _shitColor;
        private bool _isOpened;

        [Inject]
        public void Construct(IInputSectorControl input, ISectorOpenHandler openHandler)
        {
            _input = input;
            _openHandler = openHandler;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
            _material = GetComponent<MeshRenderer>().material;
            _material.color = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
            _lightColor = _states.First(cardState => cardState.State == State.State.Light).Object.Color;
            _shitColor = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
        }

        public string UniqueCode() => transform.position + gameObject.name;

        private void OnMouseUp()
        {
            if (_input.IsPressOnSector() == false) return;
            _openHandler.Invoke(new SectorOpenCommand(UniqueCode()));
        }

        public void UpdateSymbol(State.State state, int value)
        {
            StopHighlight();
            _isOpened = true;

            var stateObject = _states.First(cardState => cardState.State == state).Object;
            _distanceText.SetText(stateObject.Text(value));
            _material.DOColor(stateObject.Color, _animationDuration);
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void Highlight()
        {
            if (_isOpened) return;
            StopHighlight();
            _material.DOColor(_lightColor, _animationDuration);
            _material.DOColor(_shitColor, _animationDuration).SetDelay(_animationDelay + _animationDuration);
        }

        public void StopHighlight()
        {
            if (_isOpened) return;
            _material.DOKill();
            _material.DOColor(_shitColor, _animationDuration);
        }
    }
}