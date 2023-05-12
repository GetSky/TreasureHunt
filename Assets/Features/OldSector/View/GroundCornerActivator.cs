using UnityEngine;

namespace Features.OldSector.View
{
    public class GroundCornerActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _centerTop;
        [SerializeField] private GameObject _centerBottom;
        [SerializeField] private GameObject _centerLeft;
        [SerializeField] private GameObject _downLeft;
        [SerializeField] private GameObject _topLeft;
        [SerializeField] private GameObject _centerRight;
        [SerializeField] private GameObject _topRight;
        [SerializeField] private GameObject _bottomRight;

        private const float Distance = 1.5f;

        public void Start()
        {
            var origin = transform.position;

            if (!Physics.Raycast(origin, Vector3.forward, out var midTopHit, Distance)) _centerTop.SetActive(true);
            if (!Physics.Raycast(origin, Vector3.back, out var midBottomHit, Distance)) _centerBottom.SetActive(true);
            if (!Physics.Raycast(origin, Vector3.left, out var midLeftHit, Distance)) _centerLeft.SetActive(true);
            if (midBottomHit.collider == null && midLeftHit.collider == null) _downLeft.SetActive(true);
            if (midTopHit.collider == null && midLeftHit.collider == null) _topLeft.SetActive(true);
            if (!Physics.Raycast(origin, Vector3.right, out var midRightHit, Distance)) _centerRight.SetActive(true);
            if (midBottomHit.collider == null && midRightHit.collider == null) _bottomRight.SetActive(true);
            if (midTopHit.collider == null && midRightHit.collider == null) _topRight.SetActive(true);
        }
    }
}