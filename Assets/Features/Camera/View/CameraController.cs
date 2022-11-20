using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Features.Camera.View
{
    public class CameraController : MonoBehaviour
    {
        [Range(0.1f, 2.0f)] [SerializeField] private float _speed = 1.0f;
        [Range(0.0f, 1.0f)] [SerializeField] private float _duration = 0.5f;
        private IInputCameraControl _input;

        [Inject]
        public void Construct(IInputCameraControl input)
        {
            _input = input;
        }

        public void LookAt(float x, float z)
        {
            var trn = transform;
            var position = trn.position;
            var deltaZ = position.y * Mathf.Tan(Mathf.Deg2Rad * (90 - trn.rotation.eulerAngles.x));
            transform.DOMove(new Vector3(x, position.y, z - deltaZ), _duration);
        }

        private void Update()
        {
            transform.position = CalculatePosition(_input.MousePosition(), transform.position);
        }

        private Vector3 CalculatePosition(Vector3 diffPosition, Vector3 currentPosition)
        {
            return new Vector3(
                currentPosition.x - diffPosition.x / (100 / _speed),
                currentPosition.y,
                currentPosition.z - diffPosition.y / (100 / _speed)
            );
        }
    }
}