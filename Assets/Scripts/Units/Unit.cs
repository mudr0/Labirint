using UnityEngine;

namespace Labirint
{
    [RequireComponent(typeof(Rigidbody), typeof(Transform))]
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;   
        
        public float _speed;
        public float _health;
        public bool _isDead;

        public virtual void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        public abstract void Move(float x, float y, float z);
    }
}
