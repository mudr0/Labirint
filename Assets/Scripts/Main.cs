using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private InputController _controller;
        private ListExecuteObjects _executeObjects;
        IEnumerator enumerator;

        private void Awake()
        {
            _controller = new InputController(_player);
            _executeObjects = new ListExecuteObjects();
            _executeObjects.AddExecuteObject(_controller);
            _executeObjects.GetEnumerator();
        }

        private void Update()
        {
            while (_executeObjects.MoveNext())
            {
                _executeObjects.CurrentExecute.Update();
            }
               
            _executeObjects.Reset();
        }
    }
}