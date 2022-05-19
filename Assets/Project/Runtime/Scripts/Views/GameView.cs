using System;
using Managers;
using Project.Runtime.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameView : ViewBaseBehaviour
    {
        [SerializeField] private Button pauseButton;

        public Button PauseButton => pauseButton;

        private void Start()
        {
            pauseButton.onClick.AddListener(PauseButtonAction);
        }

        void PauseButtonAction()
        {
            GameManager.instance.uiManager.pauseView.Open();
        }
    }
}
