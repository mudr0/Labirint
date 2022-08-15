using System;
using UnityEngine.UI;

namespace Labirint
{
    public class UIDisplayWinLabel
    {
        private Text _winText;

        public UIDisplayWinLabel(Text winText)
        {
            _winText = winText;
            winText.text = String.Empty;
        }

        public void Display()
        {
            _winText.text = "YOU WIN!";
        }
    }
}
