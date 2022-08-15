using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Labirint
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [SerializeField] private Text _pointsText;
        [SerializeField] private Text _gameOverText;
        [SerializeField] private Text _winText;
        [SerializeField] Button _restartOverButton;

        private UIDisplayPoints _displayPoints;
        private UIDisplayGameOver _displayGameOver;
        private UIDisplayWinLabel _displayWinLabel;

        private CameraController _cameraController;
        private InputController _inputController;
        private ListExecuteObjects _executeObjects;
        private int _bonusCount;
        private int _totalPoints = 0;

        private void Awake()
        {
            Time.timeScale = 1;

            _inputController = new InputController(_player);
            _cameraController = new CameraController(_player.transform, Camera.main.transform);

            _displayPoints = new UIDisplayPoints(_pointsText);
            _displayGameOver = new UIDisplayGameOver(_gameOverText);
            _displayWinLabel = new UIDisplayWinLabel(_winText);

            _restartOverButton.onClick.AddListener(Restart);
            _restartOverButton.gameObject.SetActive(false);

            _executeObjects = new ListExecuteObjects();
            _executeObjects.AddExecuteObject(_inputController);
            _executeObjects.AddExecuteObject(_cameraController);
            _executeObjects.GetEnumerator();

            foreach (var executeObject in _executeObjects)
            {
                if(executeObject is GoodBonus goodBonus)
                {
                    goodBonus.OnAddPoint += AddPoint;
                    _totalPoints++;
                }
                if(executeObject is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;
                }
            }
        }

        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayPoints.Display(_bonusCount);
            if (_bonusCount == _totalPoints)
            {
                _displayWinLabel.Display();
                Time.timeScale = 0;
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            _displayGameOver.Display();
            _restartOverButton.gameObject.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
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