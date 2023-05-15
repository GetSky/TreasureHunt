﻿using System.Globalization;
using System.Linq;
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
        [SerializeField] private GameObject _chest;
        [SerializeField] private CardState[] _states;

        private IInputSectorControl _input;
        private TextMeshPro _distanceText;

        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        private Gateway _sectorGateway;
        private SectorPresenter _presenter;
        private HighlightComponent _highlightComponent;
        private bool _isOpened;

        [Inject]
        public void Construct(SectorPresenter presenter, Gateway sectorGateway, IInputSectorControl input)
        {
            _input = input;
            _presenter = presenter;
            _sectorGateway = sectorGateway;

            _presenter.OnChangedHighlight += isHighlight =>
            {
                if (_isOpened) return;
                if (isHighlight) _highlightComponent.Highlight();
                else _highlightComponent.StopHighlight();
            };
            _presenter.OnDestroyed += () => Destroy(gameObject);
            _presenter.OnOpened += UpdateSymbol;

            _highlightComponent = GetComponentInChildren<HighlightComponent>();
        }

        private void Awake()
        {
            _distanceText = GetComponentInChildren<TextMeshPro>();
        }

        private void OnMouseUp()
        {
            if (_input.IsPressOnSector() == false) return;

            var position = transform.position;
            var id = position.x.ToString(CultureInfo.CurrentCulture) + position.z.ToString(CultureInfo.CurrentCulture);
            _sectorGateway.Schedule(new OpenSectorCommand(id));
        }

        private void UpdateSymbol(Features.Sector.View.State.State state, int value)
        {
            _highlightComponent.StopHighlight();
            _isOpened = true;

            if (state == Features.Sector.View.State.State.Treasure)
            {
                _chest.SetActive(true);
                _chest.GetComponent<Animator>().SetBool(IsOpen, true);
            }

            var stateObject = _states.First(cardState => cardState.State == state).Object;
            _distanceText.SetText(stateObject.Text(value));
            _highlightComponent.SetColor(stateObject.Color);
        }
    }
}