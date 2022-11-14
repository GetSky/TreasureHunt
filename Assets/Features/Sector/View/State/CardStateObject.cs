using System;
using UnityEngine;

namespace Features.Sector.View.State
{
    public enum State
    {
        Shirt,
        Light,
        Empty,
        Distance,
        TooFar,
        Treasure
    }

    [Serializable]
    public struct CardState
    {
        [SerializeField] private State _state;
        public State State => _state;
        [SerializeField] private CardStateObject _object;
        public CardStateObject Object => _object;
    }

    [CreateAssetMenu(fileName = "NameState", menuName = "Card State", order = 0)]
    public class CardStateObject : ScriptableObject
    {
        [SerializeField] private Color _color;
        public Color Color => _color;
        [SerializeField] private string _text;
        public string Text(int value) => string.Format(_text, value);
    }
}