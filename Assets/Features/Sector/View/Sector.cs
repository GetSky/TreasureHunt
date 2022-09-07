﻿using Features.Sector.Handler;
using TMPro;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class Sector : MonoBehaviour, ISymbolView
    {
        private ISectorOpenHandler _openHandler;
        private bool _isTreasure;
        private TextMeshPro _distanceText;

        [Inject]
        public void Construct(ISectorOpenHandler openHandler)
        {
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
    }
}