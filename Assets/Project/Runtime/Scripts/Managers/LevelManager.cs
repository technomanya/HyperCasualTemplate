using System;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;
using ElephantSDK;

namespace Project.Runtime.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public List<LevelBehaviour> levels;

        public LevelBehaviour currentLevel;

        public Action levelStartAction;
        public Action levelCompleteAction;
        public Action levelFailedAction;

        private GameManager gm;

        private void Awake()
        {
            gm = GameManager.instance;
            gm.levelManager = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            levelStartAction += LevelStart;
            levelCompleteAction += LevelComplete;
            levelFailedAction += LevelFailed;
        }

        private void LevelStart()
        {
            Elephant.Core.Elephant.LevelStarted(gm.levelId);
        }

        private void LevelComplete()
        {
            Elephant.Core.Elephant.LevelCompleted(gm.levelId);
            var newLevelId = gm.levelId++;
            PlayerPrefs.SetInt("levelId",newLevelId);
        }

        private void LevelFailed()
        {
            Elephant.Core.Elephant.LevelFailed(gm.levelId);
        }

        public void Restart()
        {
            
        }

        public void TransitionNextLevel()
        {
            
            Destroy(currentLevel.gameObject);
            var levelScore = currentLevel.levelScore;
            var newLevel = Instantiate(levels[GameManager.instance.levelId]);
            currentLevel = newLevel.GetComponent<LevelBehaviour>();
            gm.UpdateUI(levelScore, currentLevel.levelName);
        }
    }
}
