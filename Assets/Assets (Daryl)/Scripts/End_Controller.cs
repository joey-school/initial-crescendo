using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Hazard":
                    txt.text = "Timmy had a bad dream...";
					DeadQuitButton.SetActive(true);
					EndLevelQuitButton.SetActive(false);
                    Reset();
                    SaveScore();
                    break;
                case "Finish":
                    txt.text = "Timmy liked this dream!";
					DeadQuitButton.SetActive(false);
					EndLevelQuitButton.SetActive(true);
					SoundManager.Instance.PlaySoundFX(Sounds.LevelCompleted);
					Reset();
                    SaveScore();
                    break;
            }
        }

        private void Reset()
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
            PauseButton.SetActive(false);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PauseSong(true); 
        }

        private void SaveScore()
        {
            if(PlayerPrefs.HasKey("Score"))
            {
                currentHighscore = PlayerPrefs.GetInt("Score");
            }
            if(currentHighscore < scoreManager.Percentage)
            {
                PlayerPrefs.SetInt("Score", scoreManager.Percentage);
            }
        }
    }
}
