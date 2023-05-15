using System.Globalization;
using System.Linq;
using DG.Tweening;
using Features.Sector.Adapters;
using Features.Sector.UseCases.OpenSector;
using Features.Sector.View.State;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class SectorView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private GameObject _chest;
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private float _animationDelay = 2.0f;
        [SerializeField] private CardState[] _states;

        private IInputSectorControl _input;
        private Material _material;
        private TextMeshPro _distanceText;
        private Color _lightColor;
        private Color _shitColor;
        private bool _isOpened;

        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        private Gateway _sectorGateway;
        private SectorPresenter _presenter;

        [Inject]
        public void Construct(SectorPresenter presenter, Gateway sectorGateway, IInputSectorControl input)
        {
            _input = input;
            _presenter = presenter;
            _sectorGateway = sectorGateway;

            _presenter.OnChangedHighlight += isHighlight =>
            {
                if (isHighlight) Highlight();
                else StopHighlight();
            };

            _presenter.OnDestroyed += DestroyView;

            _presenter.OnOpened += UpdateSymbol;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
            _material = _meshRenderer.material;
            _material.color = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
            _lightColor = _states.First(cardState => cardState.State == State.State.Light).Object.Color;
            _shitColor = _states.First(cardState => cardState.State == State.State.Shirt).Object.Color;
        }

        private void OnMouseUp()
        {
            if (_input.IsPressOnSector() == false) return;

            var position = transform.position;
            var id = position.x.ToString(CultureInfo.CurrentCulture) + position.z.ToString(CultureInfo.CurrentCulture);
            _sectorGateway.Schedule(new OpenSectorCommand(id));
        }

        public void UpdateSymbol(Features.Sector.View.State.State state, int value)
        {
            StopHighlight();

            _isOpened = true;
            if (state == Features.Sector.View.State.State.Treasure)
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