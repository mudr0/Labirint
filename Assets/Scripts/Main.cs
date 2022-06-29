using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private InputController _controller;

        private void Awake()
        {
            _controller = new InputController(_player);
        }

        private void Update()
        {
            _controller.Update();
        }
    }
}