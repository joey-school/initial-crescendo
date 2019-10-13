using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Crescendo.InitialCrescendo
{
    public class Pause_Controller : MonoBehaviour
    {
        [SerializeField] private GameObject PauseButton;
        [SerializeField] private GameObject PausePanel;
        private Scene scene;

        void Start()
        {
            scene = SceneManager.GetActiveScene();
        }

        // When the pause button is pressed during the game
        public void EnablePauseMenu()
        {
            PauseButton.SetActive(false); 
            PausePanel.SetActive(true);
            Time.timeScale = 0f;

            // Bugfix: Used to fix pause super jump.
            GameObject.Find("Player").GetComponent<PlayerMovementController>().Rigidbody.velocity = Vector2.zero;
            //
        }

        // When resume game button is pressed
        public void DisablePauseMenu()
        {
            PauseButton.SetActive(true);
            PausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }

        // When the reload button is pressed
        public void ReloadLevel()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(scene.name);
        }

        // When the quit button is pressed
        public void QuitLevel()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(LevelManager.Instance.MainMenuName);
        }
    }
}