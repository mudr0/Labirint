using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public class InputController
    {
        private Unit _player;

        private float _horizontal;
        private float _vertical;

        public InputController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _player.Move(_horizontal, 0f, _vertical);
        }
    }
}
