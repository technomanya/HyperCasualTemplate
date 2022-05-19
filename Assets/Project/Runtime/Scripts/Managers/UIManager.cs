using System;
using Project.Runtime.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameView gameView;
        public LevelCompleteView levelCompleteView;
        public LevelFailedView levelFailedView;
        public PauseView pauseView;
        public Text levelText;
        public Text scoreText;
        [SerializeField] private Button startButton;
        public Button StartButton => startButton;

        private void Awake()
        {
            GameManager.instance.uiManager = this;
        }

        void Start()
        {
            startButton.onClick.AddListener(StartButtonAction);
        }

        void StartButtonAction()
        {
            gameView.Open();
            GameManager.instance.StartGame();
        }
    }
}
