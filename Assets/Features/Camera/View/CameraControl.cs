using DG.Tweening;
using Features.Camera.Adapters;
using UnityEngine;
using Zenject;

namespace Features.Camera.View
{
    public class CameraControl : MonoBehaviour
    {
        [Range(0.1f, 2.0f)] [SerializeField] private float _speed = 1.0f;
        [Range(0.0f, 1.0f)] [SerializeField] private float _duration = 0.5f;

        private IInputCameraControl _input;
        private ICameraPresenter _presenter;

        [Inject]
        public void Construct(IInputCameraControl input, ICameraPresenter presenter)
        {
            _input = input;
            _presenter = presenter;
        }

        private void LookAt(float x, float z, bool isImmediately = false)
        {
            var trn = transform;
            var position = trn.position;
            var deltaZ = position.y * Mathf.Tan(Mathf.Deg2Rad * (90 - trn.rotation.eulerAngles.x));
            transform.DOMove(new Vector3(x, position.y, z - deltaZ), isImmediately ? 0.0f : _duration);
        }

        private Vector3 CalculatePosition(Vector3 diffPosition, Vector3 currentPosition)
        {
            return new Vector3(
                currentPosition.x - diffPosition.x / (100 / _speed),
                currentPosition.y,
                currentPosition.z - diffPosition.y / (100 / _speed)
            );
        }

        private void OnEnable()
        {
            _presenter.OnLookedAt += LookAt;
            var position = _presenter.GetCurrentPosition();
            LookAt(position.x, position.z, true);
        }

        private void Update()
        {
            transform.position = CalculatePosition(_input.MousePosition(), transform.position);
        }

        private void OnDisable()
        {
            _presenter.OnLookedAt -= LookAt;
        }
    }
}