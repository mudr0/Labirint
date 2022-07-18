using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class GoodBonus : Bonus, IFly, IRotate
    {
        [SerializeField] private float _flyHeight;
        [SerializeField] private float _rotationSpeed;

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHeight), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed, Space.World);
        }

        private void Update()
        {
            Fly();
            Rotate();
        }
    }
}
