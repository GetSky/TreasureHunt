using UnityEngine;

namespace Features.Sector.View
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
        
        public void Start()
        {
            RaycastHit hit;

            if (!Physics.Raycast(transform.position, Vector3.forward, out hit,
                    1.5f))
            {
                _centerTop.SetActive(true);
            }
            
            RaycastHit hit2;
            if (!Physics.Raycast(transform.position, -1*Vector3.forward, out hit2,
                    1.5f))
            {
                _centerBottom.SetActive(true);
            } 
            
            RaycastHit hit3;
            if (!Physics.Raycast(transform.position, Vector3.left, out hit3,
                    1.5f))
            {
                _centerLeft.SetActive(true);
            }
            
            if (hit2.collider == null && hit3.collider == null) _downLeft.SetActive(true);
            if (hit.collider == null && hit3.collider == null) _topLeft.SetActive(true);
            
            RaycastHit hit4;
            if (!Physics.Raycast(transform.position, Vector3.right, out hit4,
                    1.5f))
            {
                _centerRight.SetActive(true);
            }
            
            if (hit2.collider == null && hit4.collider == null) _bottomRight.SetActive(true);
            if (hit.collider == null && hit4.collider == null) _topRight.SetActive(true);
        }
    }
}