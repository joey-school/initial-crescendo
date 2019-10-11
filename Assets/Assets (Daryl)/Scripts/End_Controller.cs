using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class End_Controller : MonoBehaviour
    {
        [SerializeField] private GameObject EndPanel;
        [SerializeField] private GameObject PauseButton;
        [SerializeField] private Text txt;
		[SerializeField] private ScoreManager scoreManager;
		[SerializeField] private GameObject DeadQuitButton;
		[SerializeField] private GameObject EndLevelQuitButton;

		private int currentHighscore = 0;
        private int totalObjects = 0;
        private string levelName;

        void Start()
        {
            int totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
            int totalInteractables = GameObject.FindGameObjectsWithTag("InteractableCollectible").Length;
            totalObjects = totalCollectibles + totalInteractables;
            levelName = SceneManager.GetActiveScene().name;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Hazard":
                    txt.text = "Timmy had a bad dream...";
					DeadQuitButton.SetActive(true);
					EndLevelQuitButton.SetActive(false);
                    ResetValues();
                    SaveScore();
                    break;
                case "Finish":
                    txt.text = "Timmy liked this dream!";
					DeadQuitButton.SetActive(false);
					EndLevelQuitButton.SetActive(true);
                    PlayerPrefs.SetInt(levelName + "finished", 1);
                    SoundManager.Instance.PlaySoundFX(Sounds.LevelCompleted);
					ResetValues();
                    SaveScore();
                    break;
            }
        }

        private void ResetValues()
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
            PauseButton.SetActive(false);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PauseSong(true); 
        }

        private void SaveScore()
        {
            int currentHighscore = 0;
            if(PlayerPrefs.HasKey(levelName + "score"))
            {
                currentHighscore = PlayerPrefs.GetInt(levelName + "score");
            }
            if(currentHighscore < scoreManager.Score)
            {
                PlayerPrefs.SetInt(levelName + "score", scoreManager.Score);
            }
            PlayerPrefs.SetInt(levelName + "totalObjects", totalObjects);
        }
    }
}
