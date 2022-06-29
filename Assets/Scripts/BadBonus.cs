using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class BadBonus : Bonus, IFly, IFlick
    {
        [SerializeField] private float _flyHeight;
        [SerializeField] private float _flickRate;

        private float _timer = 0;
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHeight), transform.position.z);
        }

        public void Flick()
        {
            if (_renderer.enabled)
                _renderer.enabled = false;
            else
                _renderer.enabled = true;
        }

        private void Update()
        {
            Fly();
            _timer += Time.deltaTime;
            if (_timer >= _flickRate)
            {
                Flick();
                _timer = 0;
            }
        }
    }
}
