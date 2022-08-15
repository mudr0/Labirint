using UnityEngine;

namespace Labirint
{
    public class Player : Unit
    {
        [SerializeField] private Transform _playerPoint;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Move(float x, float y, float z)
        {
            _playerPoint.position = new Vector3(transform.position.x, _playerPoint.position.y, transform.position.z);
            if(_rb)
                _rb.AddForce(new Vector3(x, y, z) * _speed);
        }
    }
}
