using System;
using UnityEngine.UI;

namespace Labirint
{
    public class UIDisplayPoints
    {
        private Text _pointsText;

        public UIDisplayPoints(Text pointsText)
        {
            _pointsText = pointsText;
            pointsText.text = String.Empty;
        }

        public void Display(int points)
        {
            _pointsText.text = "Points: " + points;
        }
    }
}
