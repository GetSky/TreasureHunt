using System.Linq;
using Core;
using DG.Tweening;
using Features.Sector.Handler;
using Features.Sector.View.State;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class Sector : MonoBehaviour, ISymbolView, IHighlightedView
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private GameObject _chest;
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private float _animationDelay = 2.0f;
        [SerializeField] private CardState[] _states;

        private IInputSectorControl _input;
        private IInteractor<SectorOpenCommand> _openInteractor;
        private Material _material;
        private TextMeshPro _distanceText;
        private Color _lightColor;
        private Color _shitColor;
        private bool _isOpened;
        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        [Inject]
        public void Construct(IInputSectorControl input, IInteractor<SectorOpenCommand> openInteractor)
        {
            _input = input;
            _openInteractor = openInteractor;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
            _material = _meshRenderer.material;
            _material.color = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
            _lightColor = _states.First(cardState => cardState.State == State.State.Light).Object.Color;
            _shitColor = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
        }

        public string UniqueCode() => transform.position + gameObject.name;

        private void OnMouseUp()
        {
            if (_input.IsPressOnSector() == false) return;
            _openInteractor.Execute(new SectorOpenCommand(UniqueCode()));
        }

        public void UpdateSymbol(State.State state, int value)
        {
            StopHighlight();
            _isOpened = true;
            if (state == State.State.Treasure)
            {
                _chest.SetActive(true);
                _chest.GetComponent<Animator>().SetBool(IsOpen, true);
            }

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