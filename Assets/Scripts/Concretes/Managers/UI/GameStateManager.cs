using Assets.Scripts.Abtractions;
using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Concretes.Managers
{
    public class GameStateManager : Manager
    {

        public void SelectLeverGame(int lever)
        {
            GameHelper.SetInt(EnumPlayerPrefs.VocabularyLever.ToString(), lever);
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;

        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResumeGame();
        }


        public void QuitGame()
        {
            Application.Quit();

        }

        public override void AdjustObjects()
        {
            throw new System.NotImplementedException();
        }
    }
}