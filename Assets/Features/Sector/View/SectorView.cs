using System.Globalization;
using System.Linq;
using Features.Sector.Adapters;
using Features.Sector.Domain;
using Features.Sector.UseCases.OpenSector;
using Features.Sector.View.State;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class SectorView : MonoBehaviour
    {
        [SerializeField] private GameObject _chest;
        [SerializeField] private CardState[] _states;

        private SectorPresenter _presenter;
        private HighlightComponent _highlightComponent;
        private IInputSectorControl _input;
        private TextMeshPro _distanceText;
        private Gateway _sectorGateway;

        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        private bool _isOpened;

        [Inject]
        public void Construct(SectorPresenter presenter, Gateway sectorGateway, IInputSectorControl input)
        {
            _input = input;
            _presenter = presenter;
            _sectorGateway = sectorGateway;
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
            _highlightComponent = GetComponentInChildren<HighlightComponent>();

            _presenter.OnDestroyed += () => Destroy(gameObject);
        }

        private void OnEnable()
        {
            _presenter.OnChangedHighlight += ChangeHighlight;
            _presenter.OnOpened += UpdateSymbol;
        }

        private void ChangeHighlight(bool isHighlight)
        {
            if (_isOpened) return;
            if (isHighlight)
                _highlightComponent.Highlight();
            else
                _highlightComponent.StopHighlight();
        }

        private void OnMouseUp()
        {
            if (_input.IsPressOnSector() == false) return;

            var position = transform.position;
            var id = position.x.ToString(CultureInfo.CurrentCulture) + position.z.ToString(CultureInfo.CurrentCulture);
            _sectorGateway.Schedule(new OpenSectorCommand(id));
        }

        private void UpdateSymbol(EffectStateType state, int value)
        {
            _highlightComponent.StopHighlight();
            _isOpened = true;

            if (state == EffectStateType.Treasure)
            {
                _chest.SetActive(true);
                _chest.GetComponent<Animator>().SetBool(IsOpen, true);
            }

            var stateObject = _states.First(cardState => cardState.State.ToString() == state.ToString()).Object;
            _distanceText.SetText(stateObject.Text(value));
            _highlightComponent.SetColor(stateObject.Color);
        }

        private void OnDisable()
        {
            _presenter.OnOpened -= UpdateSymbol;
            _presenter.OnChangedHighlight -= ChangeHighlight;
        }
    }
}