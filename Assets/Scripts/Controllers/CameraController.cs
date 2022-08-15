using UnityEngine;

namespace Labirint
{
    public class CameraController : IExecute
    {
        private Transform _camera;
        private Transform _player;
        private Vector3 _offset;

        public CameraController(Transform player, Transform camera)
        {
            _camera = camera;
            _player = player;
            _offset = _camera.position - _player.position;
            _camera.LookAt(_player);
        }

        public void Update()
        {
            _camera.position = _player.position + _offset;
        }
    }
}
