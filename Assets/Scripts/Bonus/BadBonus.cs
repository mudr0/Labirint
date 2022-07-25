using System;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class BadBonus : Bonus, IFly, IFlick
    {
        [SerializeField] private float _flyHeight;

        public event Action OnGameOver = delegate { };
        private Material _material;

        public override void Awake()
        {
            base.Awake();
            _material = Renderer.material;
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHeight), transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1));
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {
            OnGameOver?.Invoke();
        }
    }
}
