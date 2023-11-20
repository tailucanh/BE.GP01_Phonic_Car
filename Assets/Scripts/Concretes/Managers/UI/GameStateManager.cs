using Assets.Scripts.Abtractions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Concretes.Managers
{
    public class GameStateManager : MonoBehaviour
    {

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
    }
}