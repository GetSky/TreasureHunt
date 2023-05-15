using DG.Tweening;
using UnityEngine;

namespace Features.Sector.View
{
    [RequireComponent(typeof(MeshRenderer))]
    public class HighlightComponent : MonoBehaviour
    {
        [SerializeField] private Color _lightColor;
        [SerializeField] private Color _shitColor;

        [SerializeField] private float _animationDelay = 2.0f;
        [SerializeField] private float _animationDuration = 0.5f;

        private Material _material;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        public void Highlight()
        {
            StopHighlight();
            _material.DOColor(_lightColor, _animationDuration);
            _material.DOColor(_shitColor, _animationDuration).SetDelay(_animationDelay + _animationDuration);
        }

        public void StopHighlight()
        {
            _material.DOKill();
            _material.DOColor(_shitColor, _animationDuration);
        }

        public void SetColor(Color color)
        {
            _material.DOColor(color, _animationDuration);
        }
    }
}