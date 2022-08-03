using System;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class GoodBonus : Bonus, IFly, IRotate
    {
        [SerializeField] private float _flyHeight;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _pointValue = 1;

        private SObject _bonusData;
        private ISaveData _data;

        public Action<int> OnAddPoint = delegate (int i) { };

        public override void Awake()
        {
            base.Awake();
            _data = new JSONData();
            _bonusData = new SObject(this.gameObject);
            _data.SaveData(_bonusData);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHeight), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed, Space.World);
        }

        protected override void Interaction()
        {
            OnAddPoint?.Invoke(_pointValue);
        }
    }
}
