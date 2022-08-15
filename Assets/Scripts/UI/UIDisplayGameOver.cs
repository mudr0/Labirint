using System;
using UnityEngine.UI;

namespace Labirint
{
    public class UIDisplayGameOver
    {
        private Text _gameOverText;

        public UIDisplayGameOver(Text gameOverText)
        {
            _gameOverText = gameOverText;
            gameOverText.text = String.Empty;
        }

        public void Display()
        {
            _gameOverText.text = "GAME OVER";
        }
    }
}